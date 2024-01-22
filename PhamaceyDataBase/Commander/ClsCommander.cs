using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace PhamaceyDataBase.Commander
{
    //اسم الوعاء الذي بداخله الداتا بيس كاملة  نجده في 
    /*ملف الانتتي .edmx 
    ثم ملف الانتتي .context.tt
    ثم ملف الانتتي .context.cs */
    public  class test
    {
        public static string ser = C_SqlCon.Server_Name;
        public static string x = @" App=EntityFramework ""; ";
        public static string connstr =
            @"metadata=res://*/Phamacey_Entity_Model.csdl|
                       res://*/Phamacey_Entity_Model.ssdl|
                       res://*/Phamacey_Entity_Model.msl;
              provider=System.Data.SqlClient;
           provider connection string ="";  data source = " + ser + " ;   initial catalog = PHANACEY_DB;     integrated security = True;   MultipleActiveResultSets=True; "+ x +"  ";
        /*   providerName="System.Data.EntityClient"*/
      
    }
    public  class ClsCommander<TEntity> : ICommander<TEntity> where TEntity : class
    {
      public static  string connstr = test.connstr;

        public static PHANACEY_DBEntities Context = new PHANACEY_DBEntities(connstr) ;
        public void Delet_Data(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            Context.SaveChanges();
        }


        public void Detached_Data(TEntity entity)
        {
            Context.Entry(entity).State = System.Data.Entity.EntityState.Detached;
        }

        public IEnumerable<TEntity> Get_All()
        {
            return Context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Get_By(Expression<Func<TEntity, bool>> p)
        {
            return Context.Set<TEntity>().Where(p);
        }

        public void Insert_Data(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            Context.SaveChanges();
            //يعني خذ من الداتا بيس التي انتتي الي معرفو ك براميتر و ضفلو الانتتي 
            //السيت لتحديد اي جدول سنتعامل معه من الداتا يس
        }

        public IEnumerable<TEntity> Max_Id(Expression<Func<TEntity, bool>> p)
        {
            return Context.Set<TEntity>().Where(p);
        }

        public void Update_Data(TEntity entity)
        {
            Context.Set<TEntity>().AddOrUpdate(entity);
            Context.SaveChanges();
        }

   
    }
}
