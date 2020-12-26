namespace Gestion_Paie.BusinessComponents {

	public interface IBusinessComponentRecord {

		bool Refresh();
		void Update();
		string ToString();
	}

	public interface IBusinessComponentCollection {

		string ConnectionString { get; }
		IBusinessComponentRecord Add(IBusinessComponentRecord record); 
		void Remove(IBusinessComponentRecord record);
		void Refresh();
	}

}
