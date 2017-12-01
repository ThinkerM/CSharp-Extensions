using System;
using System.Windows.Forms;

namespace ThinkerExtensions.Controls
{
    /// <summary>
    /// Provides extensions methods for <see cref="Control"/>s
    /// </summary>
    public static class ControlExtensions
    {
        /// <summary>
        /// Executes the Action asynchronously on the UI thread, does not block execution on the calling thread.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="code">Action to execute on the UI thread</param>
        public static void UiThread(this Control control, Action code)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(code);
            }
            else
            {
                code.Invoke();
            }
        }

        /// <summary>
        /// Make the <see cref="Form"/> visible if it currently isn't and bring it to foreground
        /// </summary>
        /// <param name="form"></param>
        public static void EnsureVisibility(this Form form)
        {
            form.WindowState = FormWindowState.Normal;
            form.BringToFront();
            form.Focus();
        }
    }
}
