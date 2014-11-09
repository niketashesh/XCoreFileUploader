XCoreFileUploader
=================

SPEAK based file upload tool for Sitecore
XCore’s file uploader control extends Sitecore’s Uploader control. It lets users select and upload files to the media library or post them to a custom controller. 

Similar to Sitecore’s Uploader, XCore File Uploader control shows an area where users can drag and drop the files from their local computer that they want to upload.  

Note: “Drag and drop” does not work in all browsers on all platforms, and local security settings can also disable it. The Uploader offers a more traditional alternative to “drag and drop”: a button that users can click to open a file selection dialog. 

The control provides users with a way to select files and a member function to upload selected files. You can raise the “upload” event from a button to trigger this function. Users can then upload selected files by clicking the button. The Uploader uploads all currently selected files. You can use the UploaderInfo control to show information about the currently selected files and the upload progress.
