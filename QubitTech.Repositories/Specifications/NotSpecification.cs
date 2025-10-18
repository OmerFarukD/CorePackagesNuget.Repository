namespace QubitTech.Repositories.Specifications;

using QubitTech.Repositories.Extensions;
public class NotSpecification<T> : BaseSpecification<T>
{
    public NotSpecification(ISpecification<T> specification)
    {
        if (specification.Criteria != null)
        {
            Criteria = specification.Criteria.Not();
        }


        Includes.AddRange(specification.Includes);
        IncludeStrings.AddRange(specification.IncludeStrings);
    }
}