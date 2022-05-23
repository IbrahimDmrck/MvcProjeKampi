using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetMessageInBoxList(string p);
        List<Message> GetMessageSendBoxList(string p);
        List<Message> GetDraftBoxList();
        void AddDraftsMessage(Message message);
        void AddMessageBL(Message message);
        Message GetByID(int id);
        void MessageDelete(Message message);
        void MessageUpdate(Message message);
        //List<Message> GetListTrashBox(string mail);
    }
}
