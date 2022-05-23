using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void AddMessageBL(Message message)
        {
            _messageDal.Insert(message);
        }

      

        public Message GetByID(int id)
        {
            return _messageDal.Get(x=>x.MessageID==id);
        }

        public List<Message> GetDraftBoxList()
        {
            //         return _messageDal.List(x => x.SenderMail == mail && x.Draft == true && x.MessageStatus == true);
            return _messageDal.List(x=>x.Draft==true  && x.ReceiverMail!="admin@gmail.com" );
        }

        //public List<Message> GetListTrashBox(string mail)
        //{
        //    return _messageDal.List(x => (x.ReceiverMail == mail || x.SenderMail == mail) && x.MessageStatus == false);
        //}

        public List<Message> GetMessageInBoxList(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p);
        }

        public List<Message> GetMessageSendBoxList(string p)
        {
            return _messageDal.List(x => x.SenderMail ==p);
        }

        public void AddDraftsMessage(Message message)
        {

            _messageDal.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            _messageDal.Update(message);
        }

        public void MessageUpdate(Message message)
        {
            _messageDal.Update(message);
        }
    }
}
