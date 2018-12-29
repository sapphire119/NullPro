namespace UnprofessionalsApp.Mapping.Contracts
{
	using AutoMapper;

	public interface IHaveCustomMappings
	{
		void CreateMappings(IMapperConfigurationExpression configuration);
	}
}
