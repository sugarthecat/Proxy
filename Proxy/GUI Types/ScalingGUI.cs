namespace Proxy
{
    internal class ScalingGUI : GUI
    {
        protected int width;
        protected int height;

        public ScalingGUI(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public virtual void RescaleElements()
        {
            ResetElements();
            ScaleGUIToFit(width, height);
        }
    }
}