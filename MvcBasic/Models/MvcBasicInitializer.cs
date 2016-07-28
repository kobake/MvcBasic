using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace MvcBasic.Models
{
    // ※ DropCreateDatabaseAlways … アプリを実行するたびにデータベースを再作成する
    public class MvcBasicInitializer : DropCreateDatabaseAlways<MvcBasicContext>
    {
        public override void InitializeDatabase(MvcBasicContext context)
        {
            Stopwatch t = new Stopwatch();
            try
            {
                t.Start();
                base.InitializeDatabase(context);
            }
            catch (Exception ex)
            {
                Debug.Print("---- InitializeDataBase failure ----");
                t.Stop();
                Debug.Print("{0} sec.", t.Elapsed.Seconds);
                Debug.Print(ex.ToString());
                Debug.Print("------------------------------------");
                throw;
            }
        }
        protected override void Seed(MvcBasicContext context)
        {
            var members = new List<Member>{
                new Member{
                    Name="山田リオ4",
                    Email = "rio@wings.msn.to",
                    Birth = DateTime.Parse("1980-06-25"),
                    Married = false,
                    Memo = "ピアノが大好きです。"
                },
                new Member{
                    Name="日尾直弘4",
                    Email = "naohiro@wings.msn.to",
                    Birth= DateTime.Parse("1975-07-19"),
                    Married = false,
                    Memo= "子どもにもやさしいお医者さんです。"
                }
            };
            members.ForEach(m => context.Members.Add(m));
            context.SaveChanges();
        }
    }
}
