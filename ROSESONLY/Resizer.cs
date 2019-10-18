using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace ResizeDemoCS
{
    class Resizer
    {
        private struct ControlInfo
        {
            public string name;
            public string parentName;
            public double leftOffsetPercent;            
            public double topOffsetPercent;
            public double heightPercent;
            public int originalHeight;
            public int originalWidth;
            public double widthPercent;
            public Single originalFontSize;
        }

        private Dictionary<string, ControlInfo> ctrlDict = new Dictionary<string, ControlInfo>();

        public void FindAllControls(Control Myctrl)
        {               
            foreach(Control ctrl in Myctrl.Controls){
                try{
                    if(ctrl.Parent != null)
                        {
                            if (ctrl.Name != "")
                            {
                                int parentHeight = ctrl.Parent.Height;
                                int parentWidth = ctrl.Parent.Width;
                                ControlInfo c = new ControlInfo();
                                c.name = ctrl.Name;
                                c.parentName = ctrl.Parent.Name;
                                c.topOffsetPercent = Convert.ToDouble(ctrl.Top) / Convert.ToDouble(parentHeight);
                                c.leftOffsetPercent = Convert.ToDouble(ctrl.Left) / Convert.ToDouble(parentWidth);
                                c.heightPercent = Convert.ToDouble(ctrl.Height) / Convert.ToDouble(parentHeight);
                                c.widthPercent = Convert.ToDouble(ctrl.Width) / Convert.ToDouble(parentWidth);
                                c.originalFontSize = ctrl.Font.Size;
                                c.originalHeight = ctrl.Height;
                                c.originalWidth = ctrl.Width;
                                ctrlDict.Add(c.name, c);
                            }
                            
                        }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message.ToString());

                }
                if(ctrl.Controls.Count > 0){
                    FindAllControls(ctrl);
                }
            }

            
           
        }

        public void ResizeAllControls(Control Myctrl)
        {
            Single fontRatioW;
            Single fontRatioH;
            Single fontRatio;
            Font f;

            foreach(Control ctrl in Myctrl.Controls){
                
                try{
                    
                        int parentHeight = ctrl.Parent.Height;
                        int parentWidth = ctrl.Parent.Width;
                        ControlInfo c = new ControlInfo();                        
                        if(ctrlDict.TryGetValue(ctrl.Name, out c)){
                            ctrl.Width = (int)(parentWidth * c.widthPercent);
                            ctrl.Height = (int)(parentHeight * c.heightPercent);

                            ctrl.Top = (int)(parentHeight * c.topOffsetPercent);
                            ctrl.Left = (int)(parentWidth * c.leftOffsetPercent);

                            f = ctrl.Font;
                            fontRatioW = ctrl.Width / c.originalWidth;
                            fontRatioH = ctrl.Height / c.originalHeight;
                            fontRatio = (fontRatioW + fontRatioH) / 2; 
                            ctrl.Font = new Font(f.FontFamily, c.originalFontSize * fontRatio, f.Style);
                        }
                    
                }catch(Exception ex){
                    //MessageBox.Show(ex.ToString());
            }
                if(ctrl.Controls.Count>0){
                    ResizeAllControls(ctrl);
                }

            }
        }
    }
}
