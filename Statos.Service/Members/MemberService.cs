using System.Collections.Generic;
using System.Linq;
using Statos.Model.Members;

namespace Statos.Service.Members
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }


        /// <summary>
        /// Create Blog Nees Letter Memeber method
        /// </summary>
        /// <param name="membersViewModel"></param>
        /// <returns></returns>
        public Member CreateMember(MemberViewModel membersViewModel)
        {
            var member = membersViewModel.ConvertToMemberModel();
            _memberRepository.Add(member);
            _memberRepository.SaveChanges();
            return member;
        }


        /// <summary>
        /// Remove Member Method !
        /// </summary>
        /// <param name="membersViewModel"></param>
        public void RemoveMember(MemberViewModel membersViewModel)
        {
            var member = membersViewModel.ConvertToMemberModel();
            _memberRepository.Delete(member);
            _memberRepository.SaveChanges();
        }


        /// <summary>
        /// Get Member By Identity
        /// </summary>
        /// <param name="memberViewModel"></param>
        /// <returns></returns>
        public MemberViewModel GetMember(MemberViewModel memberViewModel)
        {
            var member = _memberRepository.FindBy(memberViewModel.MemberId);
            var memberView = member.ConvertToMemberViewModel();
            return memberView;
        }


        /// <summary>
        /// Returns all the members of the blog
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MemberViewModel> GetAllMembers()
        {
            var member = _memberRepository.GetAll().OrderByDescending(m => m.CreationTime);
            var memberViewModel = member.ConvertToMemberViewModelList();
            return memberViewModel;

        }
    }
}
