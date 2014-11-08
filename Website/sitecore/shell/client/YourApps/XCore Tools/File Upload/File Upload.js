define(["sitecore"], function (Sitecore) {
    var FileUpload = Sitecore.Definitions.App.extend({
        initialized: function () {
            this.UploadButton.on("click", function () {
                if (this.UploadFiles.viewModel.totalFiles() < 1)
                    alert("Please select a file");
                else {
                    this.UploadFiles.viewModel.upload();
                }
            }, this);
        }
    });
    return FileUpload;
});