namespace SystemTools
{
    using System;
    using System.Diagnostics;
    using System.IO;

    public class CommandExcuter
    {
        private string _errorMessage;
        private string _outMessage;
        private string _workingDirectory;
        private Process process;
        private ProcessStartInfo startInfo;

        public CommandExcuter(string workingDirectory)
        {
            this._errorMessage = "";
            this._outMessage = "";
            base..ctor();
            this._workingDirectory = workingDirectory;
            this.process = new Process();
            this.Init();
            return;
        }

        public void Execute(string cmd)
        {
            this.process.Start();
            this.process.StandardInput.WriteLine(cmd);
            this.process.BeginOutputReadLine();
            this.process.BeginErrorReadLine();
            this.process.WaitForExit();
            return;
        }

        public void ExecuteFile(string path)
        {
            string str;
            str = File.ReadAllText(path);
            this.Execute(str);
            return;
        }

        private void Init()
        {
            this.startInfo = new ProcessStartInfo("cmd.exe");
            this.startInfo.RedirectStandardError = 1;
            this.startInfo.RedirectStandardInput = 1;
            this.startInfo.RedirectStandardOutput = 1;
            this.startInfo.UseShellExecute = 0;
            this.startInfo.WorkingDirectory = this._workingDirectory;
            this.process.StartInfo = this.startInfo;
            this.process.ErrorDataReceived += new DataReceivedEventHandler(this.Process_ErrorDataReceived);
            this.process.OutputDataReceived += new DataReceivedEventHandler(this.Process_OutputDataReceived);
            this._errorMessage = "";
            this._outMessage = "";
            return;
        }

        private void Process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            this._errorMessage = this._errorMessage + "\n" + e.Data;
            return;
        }

        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            this._outMessage = this._outMessage + "\n" + e.Data;
            return;
        }

        public string ErrorMessage =>
            this._errorMessage;

        public string OutMessage =>
            this._outMessage;
    }
}

