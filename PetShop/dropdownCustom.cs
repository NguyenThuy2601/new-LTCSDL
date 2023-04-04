using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace PetShop
{
    public class dropdownCustom : ProfessionalColorTable
    {
        private Color backColor;
        private Color leftColumnColor;
        private Color borderColor;
        private Color menuItemBorderColor;
        private Color menuItemSelectedColor;


        public dropdownCustom(bool isMainMenu, Color primaryColor)
        {
            if (isMainMenu)
            {
                backColor = Color.FromArgb(37, 39, 60);
                leftColumnColor = Color.Indigo;
                borderColor = Color.Indigo;
                menuItemBorderColor = primaryColor;
                menuItemSelectedColor = primaryColor;
            }
            else
            {
                backColor = Color.White;
                leftColumnColor = Color.Indigo;
                borderColor = Color.Indigo;
                menuItemSelectedColor = primaryColor;
                menuItemBorderColor = primaryColor;
            }
        }


        public override Color ToolStripDropDownBackground
        {
            get
            {
                return backColor;
            }

        }


        public override Color MenuBorder
        {
            get
            {
                return borderColor;
            }
        }


        public override Color MenuItemBorder
        {
            get
            {
                return menuItemBorderColor;
            }
        }


        public override Color MenuItemSelected
        {
            get
            {
                return menuItemSelectedColor;
            }
        }


        public override Color ImageMarginGradientBegin
        {
            get
            {
                return leftColumnColor;
            }

        }

        public override Color ImageMarginRevealedGradientMiddle
        {
            get
            {
                return leftColumnColor;
            }
        }


        public override Color ImageMarginGradientEnd
        {
            get
            {
                return leftColumnColor;
            }
        }
    }
}
