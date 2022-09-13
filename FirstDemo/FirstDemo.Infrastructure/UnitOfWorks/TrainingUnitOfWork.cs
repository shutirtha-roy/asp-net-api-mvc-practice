using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace FirstDemo.Infrastructure.UnitOfWorks
{
    public class TrainingUnitOfWork
    {
        private List<object> _itemsToAdd;
        private List<object> _itemsToDelete;
        private List<object> _itemsToModify;

        public void Add(object item)
        {
            _itemsToAdd.Add(item);
        }

        public void Save()
        {
            using Transaction transaction;

            try
            {
                foreach(var i in _itemsToAdd)
                {
                    // Find Repository
                    // Add to Repository
                }

                foreach(var i in _itemsToDelete)
                {

                }

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
            }
        }
    }
}
