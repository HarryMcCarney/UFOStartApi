$cmd = "$OctopusPackageDirectoryPath" + "\UFOStart.MailQueue.exe"

& $cmd "stop"
& $cmd "uninstall"
& $cmd "install"
& $cmd "start"