using GZFramework.UI.Dev.LibForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace _GZFramework.Demo.Library
{
    public class ModuleFunction
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FormType">�Ӵ�����,����̳���frmBaseFunction</param>
        /// <param name="Text">�Ӵ�������</param>
        /// <param name="PNGName">ͼƬ��СΪ64x64</param>
        public ModuleFunction(Type FormType, string Text, string PNGName)
        {
            ChildForm = FormType;//�Ӵ�����
            FunctionName = Text;//�Ӵ�������
            FunctionPng = PNGName;//ͼƬ��СΪ64x64
        }

        #region ����
        /// <summary>
        /// �Ӵ�����
        /// </summary>
        private Type ChildForm { get; set; }

        /// <summary>
        /// ��ǰ��������
        /// </summary>
        public string FunctionName
        {
            get;
            set;
        }

        /// <summary>
        /// ͼƬ����
        /// </summary>
        public string FunctionPng { get; set; }

        /// <summary>
        /// ��ǰ����ID
        /// </summary>
        public string FunctionID
        {
            get
            {
                return ChildForm.Name;
            }
        }

        /// <summary>
        /// ��ǰ��������ģ��ID��DLL���ƣ�
        /// </summary>
        public string ModuleID
        {
            get
            {
                return ChildForm.Assembly.GetName().Name;
            }
        }

        #endregion

        public Form LoadForm(Form MIDParent)
        {
            if (frmFun == null)
            {
                try
                {
                    frmFun = ChildForm.Assembly.CreateInstance(ChildForm.FullName) as Form;
                    frmFun.Text = FunctionName;
                    if (MIDParent != null)
                    {
                        frmFun.MdiParent = MIDParent;
                    }
                }
                catch (Exception ex)
                {
                    throw ex.InnerException;
                }
            }
            return frmFun;
        }


        /// <summary>
        /// ��ǰ�û��ù��ܵ�Ȩ��
        /// </summary>
        public int UserAuthority { get; set; }

        private Form _frm;
        protected Form frmFun
        {
            get
            {
                return _frm;
            }
            set
            {
                _frm = value;
                if (_frm == null) return;

                //����Ȩ��1073741823,���֧��30��Ȩ��
                (_frm as frmBaseChild).UserAuthority = UserAuthority;

                _frm.FormClosing += _frm_FormClosing;
            }
        }
        void _frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmFun = null;
        }

    }
}
