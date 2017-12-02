using System;
using System.Threading.Tasks;
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

        /// <summary>
        /// Gradually increase the form's opacity, making it fully visible
        /// </summary>
        /// <param name="form">Form to fade in</param>
        /// <param name="interval">(Milliseconds) Delay between each opacity gradient shift</param>
        public static async void FadeIn(this Form form, int interval = 80)
        {
            //Form is not fully visible => keep fading in
            while (form.Opacity < 1.0)
            {
                await Task.Delay(interval);
                form.Opacity += 0.05;
            }
            form.Opacity = 1; //make fully visible 
        }

        /// <summary>
        /// Gradually decrease the form's opacity, eventually making it invisible
        /// </summary>
        /// <param name="form">Form to fade out</param>
        /// <param name="interval">(Milliseconds) Delay between each opacity gradient shift</param>
        public static async void FadeOut(this Form form, int interval = 80)
        {
            //Form is still visible => keep fading out
            while (form.Opacity > 0.0)
            {
                await Task.Delay(interval);
                form.Opacity -= 0.05;
            }
            form.Opacity = 0; //make fully invisible 
        }
    }
}
