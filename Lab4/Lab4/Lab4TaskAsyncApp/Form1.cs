using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4TaskAsyncApp
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource _cancellationTokenSource;   // field to control the cancellation

        public Form1()                                              // initializes form's components
        {
            InitializeComponent();
        }

        private async void btnStart_Click(object sender, EventArgs e)   // asynchronous event handler
        {
            _cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = _cancellationTokenSource.Token;

            btnStart.Enabled = false;
            btnCancel.Enabled = true;
            lblProgress.Text = "0%";
            progressBar.Value = 0;

            var progress = new Progress<int>(value =>              // reports progress updates
            {
                lblProgress.Text = $"{value}%";
                progressBar.Value = value;
            });

            try
            {
                int result = await Process(100, progress, token);  //  asynchronous task 
                if (result == 100)
                {
                    lblProgress.Text = "Task is finished.";
                }
            }
            finally
            {
                btnStart.Enabled = true;
                btnCancel.Enabled = false;
            }
        }

        Task<int> Process(int count, IProgress<int> ChangeProgressBar, CancellationToken cancellTocken)
        {
            return Task.Run(() =>
            {
                for (int i = 1; i <= count; i++)
                {
                    if (cancellTocken.IsCancellationRequested)   // if cancel was called
                    {
                        lblProgress.Text = "Task was canceled.";
                        progressBar.Value = 0;
                        return i;
                    }
                    ChangeProgressBar.Report(i);
                    Thread.Sleep(100);
                }
                return count;
            });
        }

        private void btnCancel_Click(object sender, EventArgs e)   // triggers cancel when Cancel button is clicked
        {
            if (_cancellationTokenSource != null)
            {
                _cancellationTokenSource.Cancel();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }
    }
}
