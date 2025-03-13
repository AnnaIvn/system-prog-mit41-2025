//using System;
//using System.Reflection.Emit;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

//namespace Lab4TaskAsyncApp
//{
//    public partial class Form1 : Form
//    {
//        private CancellationTokenSource _cancellationTokenSource;   // field to control the cancellation

//        public Form1()                                              // initializes form's components
//        {
//            InitializeComponent();
//        }

//        private async void btnStart_Click(object sender, EventArgs e)   // asynchronous event handler
//        {
//            //_cancellationTokenSource = new CancellationTokenSource();
//            //CancellationToken token = _cancellationTokenSource.Token;   // token to monitor cancellation requests

//            //btnStart.Enabled = false;
//            //btnCancel.Enabled = true;
//            //lblProgress.Text = "0%";
//            //progressBar.Value = 0;

//            //var progress = new Progress<int>(value =>                   // reports progress updates
//            //{
//            //    lblProgress.Text = $"{value}%";
//            //    progressBar.Value = value;
//            //});

//            //try
//            //{
//            //    await Task.Run(() => DoWork(progress, token), token);  //  asynchronous task 
//            //    lblProgress.Text = "Task is finished.";
//            //}
//            //catch (OperationCanceledException)                         // cancel exception catcher
//            //{
//            //    lblProgress.Text = "Task was canceled.";
//            //    progressBar.Value = 0;
//            //}
//            //finally
//            //{
//            //    btnStart.Enabled = true;
//            //    btnCancel.Enabled = false;
//            //}

//            IProgress<int> onChangeProgress = new Progress<int>((i) =>
//            {
//                lblProgress.Text = i.ToString();
//                progressBar.Value = i;
//            });
//            CancellationTokenSource cts = new CancellationTokenSource();
//            btnCancel.Click += delegate { cts.Cancel(); };
//            lblProgress.Text = (await Process(100,
//            onChangeProgress, cts.Token)).ToString();
//        }

//        Task<int> Process(int count, IProgress<int> ChangeProgressBar,
//        CancellationToken cancellTocken)
//        {
//            return Task.Run(() =>
//            {
//                int i;
//                for (i = 1; i <= count; i++)
//                {
//                    if (cancellTocken.IsCancellationRequested)
//                        return i;
//                    ChangeProgressBar.Report(i);
//                    Thread.Sleep(100);
//                }
//                return i;
//            });
//        }



//        //private void DoWork(IProgress<int> progress, CancellationToken token)   // updates progress from 0 to 100
//        //{
//        //    for (int i = 0; i <= 100; i++)
//        //    {
//        //        token.ThrowIfCancellationRequested();      // checks if a cancellation request has been made
//        //        progress.Report(i);
//        //        Thread.Sleep(100);
//        //    }
//        //}

//        private void btnCancel_Click(object sender, EventArgs e)   // triggers catch cancel exception when Cancel button is clicked
//        {
//            if (_cancellationTokenSource != null)
//            {
//                _cancellationTokenSource.Cancel();
//            }
//        }

//        private void button1_Click(object sender, EventArgs e)
//        {
//        }

//        private void Form1_Load(object sender, EventArgs e)
//        {
//        }

//        private void groupBox1_Enter(object sender, EventArgs e)
//        {
//        }
//    }
//}


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
            catch (OperationCanceledException)                    // cancel exception catcher
            {
                lblProgress.Text = "Task was canceled.";
                progressBar.Value = 0;
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
                        throw new OperationCanceledException();
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
