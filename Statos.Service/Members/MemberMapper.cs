using System.Collections.Generic;
using AutoMapper;
using Statos.Model.Members;

namespace Statos.Service.Members
{
    public static  class MemberMapper
    {
        /// <summary>
        /// Convert MemberViewModel To Member Extrenstion Menthod
        /// </summary>
        /// <param name="membersViewModel"></param>
        /// <returns></returns>
        public static Member ConvertToMemberModel(this MemberViewModel membersViewModel)
        {
            Mapper.CreateMap<Member, MemberViewModel>()
                  .ForMember(mem => mem.MemberId, me => me.MapFrom(m => m.Id));
            return Mapper.Map<MemberViewModel, Member>(membersViewModel);
        }


        /// <summary>
        /// Convert to MemberViewModel
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public static MemberViewModel ConvertToMemberViewModel(this Member member)
        {
            Mapper.CreateMap<MemberViewModel, Member>()
                  .ForMember(mem => mem.Id, me => me.MapFrom(m => m.MemberId));
            return Mapper.Map<Member, MemberViewModel>(member);
        }


        /// <summary>
        /// Convert to Member View Model List
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public static IEnumerable<MemberViewModel> ConvertToMemberViewModelList(this IEnumerable<Member> member)
        {
            Mapper.CreateMap<MemberViewModel, Member>()
                  .ForMember(mem => mem.Id, me => me.MapFrom(m => m.MemberId));
            return Mapper.Map<IEnumerable<Member>, IEnumerable<MemberViewModel>>(member);
        }

    }
}
