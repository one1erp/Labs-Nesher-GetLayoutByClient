using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Common;
using LSEXT;
using LSSERVICEPROVIDERLib;


namespace GetLayoutByClient
{
    [ComVisible(true)]
    [ProgId("GetLayoutByClient.GetLayoutByClientcls")]
    public class GetLayoutByClientcls : IGenericExtension
    {
        private INautilusServiceProvider sp;

        public ExecuteExtension CanExecute(ref IExtensionParameters Parameters)
        {
            return ExecuteExtension.exEnabled;
        }

        public void Execute(ref LSExtensionParameters Parameters)
        {
            sp = Parameters["SERVICE_PROVIDER"];
            var ntlsCon = Utils.GetNtlsCon(sp);
            Utils.CreateConstring(ntlsCon);

            Form1 aForm1 = new Form1();
            aForm1.Show();






        }
    }
}
