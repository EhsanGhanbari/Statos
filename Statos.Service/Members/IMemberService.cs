using System.Collections.Generic;
using Statos.Model.Members;

namespace Statos.Service.Members
{
    public interface IMemberService
    {
        Member CreateMember(MemberViewModel membersViewModel);
        void RemoveMember(MemberViewModel membersViewModel);
        MemberViewModel GetMember(MemberViewModel membersViewModel);
        IEnumerable<MemberViewModel> GetAllMembers();

    }
}
