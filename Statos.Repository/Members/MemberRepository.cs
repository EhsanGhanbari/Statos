using Statos.Model.Members;

namespace Statos.Repository.Members
{
    public class MemberRepository:Repository<Member>,IMemberRepository
    {
        public MemberRepository(StatosContext statosContext) : base(statosContext)
        {
        }
    }
}
