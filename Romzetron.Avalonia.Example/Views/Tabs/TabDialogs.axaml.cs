using System;
using System.Collections.Generic;
using System.IO;
using System.Reactive;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using ReactiveUI;

namespace Romzetron.Avalonia.Example.Views.Tabs;

//==================================================
// Enumerations.
//==================================================

public enum OpenFileType
{
    SingleFile,
    MultipleFiles,
    SingleFolder,
    MultipleFolders
}

//##################################################
// TabDialogs user control class.
//##################################################

public partial class TabDialogs : UserControl
{
    //==================================================
    // Private variables.
    //==================================================

    private OpenFileType _openType = OpenFileType.SingleFile;

    //==================================================
    // Commands.
    //==================================================

    public ReactiveCommand<OpenFileType, Unit> SelectOpenType { get; }

    //==================================================
    // Constructor.
    //==================================================

    public TabDialogs()
    {
        InitializeComponent();

        DataContext = this;

        SelectOpenType = ReactiveCommand.Create<OpenFileType>(openFileType =>
        {
            OpenFileContent.Text = string.Empty;
            _openType = openFileType;

            OpenFileButton.Content = openFileType switch
            {
                OpenFileType.SingleFile => "Open Single File",
                OpenFileType.MultipleFiles => "Open Multiple Files",
                OpenFileType.SingleFolder => "Open Single Folder",
                OpenFileType.MultipleFolders => "Open Multiple Folders",
                _ => OpenFileButton.Content
            };

            switch (openFileType)
            {
                case OpenFileType.SingleFile or OpenFileType.MultipleFiles:
                    FileTypeComboBox.IsEnabled = true;
                    break;
                case OpenFileType.SingleFolder or OpenFileType.MultipleFolders:
                    FileTypeComboBox.SelectedIndex = 0;
                    FileTypeComboBox.IsEnabled = false;
                    break;
            }
        });
    }

    //==================================================
    // Control loaded event handler.
    //==================================================

    protected override void OnLoaded(RoutedEventArgs e)
    {
        var topLevel = TopLevel.GetTopLevel(this);

        if (topLevel is not null)
        {
            CanOpenCheckBox.IsChecked = topLevel.StorageProvider.CanOpen;
            CanSaveCheckBox.IsChecked = topLevel.StorageProvider.CanSave;
            CanPickFolderCheckBox.IsChecked = topLevel.StorageProvider.CanPickFolder;
        }
        else
        {
            CanOpenCheckBox.IsEnabled = false;
            CanSaveCheckBox.IsEnabled = false;
            CanPickFolderCheckBox.IsEnabled = false;
        }

        base.OnLoaded(e);
    }

    //==================================================
    // Open file and display contents.
    //==================================================

    private async void OpenFileButton_OnClick(object? sender, RoutedEventArgs e)
    {
        OpenFileContent.Text = "";
        var fileTypes = new List<FilePickerFileType> { FilePickerFileTypes.All };

        if (FileTypeComboBox.SelectedIndex == 1)
        {
            fileTypes = new List<FilePickerFileType>
            {
                new("Text Files (*.txt)")
                {
                    Patterns = FilePickerFileTypes.TextPlain.Patterns,
                    AppleUniformTypeIdentifiers = FilePickerFileTypes.TextPlain.AppleUniformTypeIdentifiers
                }
            };
        }

        if (FileTypeComboBox.SelectedIndex == 2)
        {
            fileTypes = new List<FilePickerFileType>
            {
                new("JSON Files (*.json)")
                {
                    Patterns = new[] { "*.json" },
                    AppleUniformTypeIdentifiers = new[] { "public.json" }
                }
            };
        }

        //--------------------------------------------------
        // Get top level from the current control.
        // Alternatively, you can use Window reference
        // instead.
        //--------------------------------------------------

        var topLevel = TopLevel.GetTopLevel(this);

        if (topLevel is null)
            return;

        switch (_openType)
        {
            //--------------------------------------------------
            // Open one or more files.
            //--------------------------------------------------

            case OpenFileType.SingleFile or OpenFileType.MultipleFiles:
            {
                var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
                {
                    Title = _openType == OpenFileType.SingleFile ? "Open File" : "Open Files",
                    FileTypeFilter = fileTypes,
                    AllowMultiple = _openType == OpenFileType.MultipleFiles
                });

                if (files.Count < 1)
                    return;

                var i = 1;

                foreach (var file in files)
                {
                    await using var stream = await file.OpenReadAsync();
                    using var streamReader = new StreamReader(stream);

                    var fileContent = await streamReader.ReadToEndAsync();

                    OpenFileContent.Text += $"##################################################{Environment.NewLine}";
                    OpenFileContent.Text += $"#  File {i++}{Environment.NewLine}";
                    OpenFileContent.Text += $"##################################################{Environment.NewLine}{Environment.NewLine}";
                    OpenFileContent.Text += fileContent;
                    OpenFileContent.Text += Environment.NewLine;
                }

                break;
            }

            //--------------------------------------------------
            // Select one or more folders.
            //--------------------------------------------------

            case OpenFileType.SingleFolder or OpenFileType.MultipleFolders:
            {
                var folders = await topLevel.StorageProvider.OpenFolderPickerAsync(new FolderPickerOpenOptions
                {
                    Title = _openType == OpenFileType.SingleFile ? "Open Folder" : "Open Folders",
                    AllowMultiple = _openType == OpenFileType.MultipleFolders
                });

                if (folders.Count < 1)
                    return;

                foreach (var folder in folders)
                    OpenFileContent.Text += $"{folder.Path.AbsolutePath}{Environment.NewLine}";
                break;
            }
        }
    }

    //==================================================
    // Save file.
    //==================================================

    private async void SaveFileButton_OnClick(object? sender, RoutedEventArgs e)
    {
        //--------------------------------------------------
        // Get top level from the current control.
        // Alternatively, you can use Window reference
        // instead.
        //--------------------------------------------------

        var topLevel = TopLevel.GetTopLevel(this);

        //--------------------------------------------------
        // Start async operation to open the dialog.
        //--------------------------------------------------

        var file = await topLevel?.StorageProvider.SaveFilePickerAsync(new FilePickerSaveOptions
        {
            Title = "Save Text File"
        })!;

        if (file is null)
            return;

        //--------------------------------------------------
        // Open writing stream from the file.
        //--------------------------------------------------

        await using var stream = await file.OpenWriteAsync();
        await using var streamWriter = new StreamWriter(stream);

        //--------------------------------------------------
        // Write some content to the file.
        //--------------------------------------------------

        var textToWrite = !string.IsNullOrEmpty(SaveFileContent.Text)
            ? SaveFileContent.Text
            : "Hello World";

        await streamWriter.WriteLineAsync(textToWrite);
    }
}