namespace SystemTools
{
    using System;
    using System.Diagnostics;
    using System.IO;

    /// <summary>
    /// 命令执行工具类
    /// </summary>
    public class CommandExcuter
    {
        private string _errorMessage;
        private string _outMessage;
        private string _workingDirectory;
        private Process process;
        private ProcessStartInfo startInfo;

        public CommandExcuter(string workingDirectory)
        {
            _errorMessage = "";
            _outMessage = "";
            
            _workingDirectory = workingDirectory;
            process = new Process();
            Init();
            return;
        }

        public void Execute(string cmd)
        {
            process.Start();
            process.StandardInput.WriteLine(cmd);
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            process.WaitForExit();
            return;
        }

        public void ExecuteFile(string path)
        {
            string str;
            str = File.ReadAllText(path);
            Execute(str);
            return;
        }

        private void Init()
        {
            startInfo = new ProcessStartInfo("cmd.exe");
            startInfo.RedirectStandardError = true;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.UseShellExecute = false;
            startInfo.WorkingDirectory = _workingDirectory;
            process.StartInfo = startInfo;
            process.ErrorDataReceived += new DataReceivedEventHandler(Process_ErrorDataReceived);
            process.OutputDataReceived += new DataReceivedEventHandler(Process_OutputDataReceived);
            _errorMessage = "";
            _outMessage = "";
            return;
        }

        private void Process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            _errorMessage = _errorMessage + "\n" + e.Data;
            return;
        }

        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            _outMessage = _outMessage + "\n" + e.Data;
            return;
        }

        public string ErrorMessage =>
            _errorMessage;

        public string OutMessage =>
            _outMessage;
    }
}

