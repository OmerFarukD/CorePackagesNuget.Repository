namespace QubitTech.Repositories.Specifications;
using QubitTech.Repositories.Extensions;
public class AndSpecification<T> : BaseSpecification<T>
{
    public AndSpecification(ISpecification<T> left, ISpecification<T> right)
    {
        if (left.Criteria != null && right.Criteria != null)
        {
            Criteria = left.Criteria.And(right.Criteria);
        }
        else if (left.Criteria != null)
        {
            Criteria = left.Criteria;
        }
        else if (right.Criteria != null)
        {
            Criteria = right.Criteria;
        }

        // Merge includes
        Includes.AddRange(left.Includes);
        Includes.AddRange(right.Includes);
        IncludeStrings.AddRange(left.IncludeStrings);
        IncludeStrings.AddRange(right.IncludeStrings);
    }
}