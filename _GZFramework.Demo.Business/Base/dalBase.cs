using GZFramework.DB.Core;
using GZFramework.DB.Lib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _GZFramework.Demo.Business.Base
{
    
    public class dalBase : dalBusinessBase
    {
      
        public dalBase()
        {
            
        }
        //��ȡ��ˮ����
        public override string GetDataSN(IDatabase db, string sDocCode, int sLength)
        {
            return sDocCode + db.ExecuteScalarSP<string>("sys_GetDataSN",
                new { DataCode = sDocCode, Length = sLength });
        }


        //�Զ����ύ
        protected override void CustomerUpdate(IDatabase db, System.Data.DataSet data, ref bool IsHandle)
        {
            base.CustomerUpdate(db, data, ref IsHandle);
        }

        //��ȡϵͳʱ�䣬����ӷ�������ȡ
        public override DateTime GetServerTime(IDatabase db)
        {
            string sql = "SELECT GETDATE()";
            return db.ExecuteScalar<DateTime>(sql);
        }
    
    }
}
