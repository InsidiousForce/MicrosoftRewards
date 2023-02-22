dotnet publish -c Release -r win-x64 -p:PublishReadyToRun=true --self-contained -p:PublishSingleFile=true -o ./.publish
copy ./.publish/MicrosoftRewards.* $Env:OneDriveConsumer/Executables/
