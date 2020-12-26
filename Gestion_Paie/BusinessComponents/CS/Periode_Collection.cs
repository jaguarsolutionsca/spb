using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	public sealed class Periode_Collection : IBusinessComponentCollection, System.Collections.IEnumerable, System.ComponentModel.IListSource {

		private System.Collections.ArrayList internalRecords;
		private bool recordsAreLoaded = false;

		private IBusinessComponentRecord parent = null;
		public IBusinessComponentRecord Parent {

			get {

				return(parent);
			}
		}

		public bool ContainsListCollection {

			get {

				return(true);
			}
		}

		public System.Collections.IList GetList() {

			return(internalRecords);
		}

		public int Count {

			get {

				if (!this.recordsAreLoaded) {

					Refresh();
				}

				return(internalRecords.Count);
			}
		}

		private string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}


		public Periode_Collection(string connectionString) {
			
			this.connectionString = connectionString;

#if OLYMARS_DEBUG
			object olymarsDebugCheck = System.Configuration.ConfigurationSettings.AppSettings["OlymarsDebugCheck"];
			if (olymarsDebugCheck == null || (string)olymarsDebugCheck == "True") {

			string DebugConnectionString = connectionString;

			if (DebugConnectionString == System.String.Empty) {

				DebugConnectionString = Gestion_Paie.DataClasses.Information.GetConnectionStringFromConfigurationFile;
			}

			if (DebugConnectionString == System.String.Empty) {

				DebugConnectionString = Gestion_Paie.DataClasses.Information.GetConnectionStringFromRegistry;
			}

			if (DebugConnectionString != String.Empty) {

				System.Data.SqlClient.SqlConnection sqlConnection = new System.Data.SqlClient.SqlConnection(DebugConnectionString);

				sqlConnection.Open();

				System.Data.SqlClient.SqlCommand sqlCommand = sqlConnection.CreateCommand();

				sqlCommand.CommandType = System.Data.CommandType.Text;
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Periode'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Periode", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

		}


		public IBusinessComponentRecord Add(IBusinessComponentRecord record) {
		
			Periode_Record recordToAdd = record as Periode_Record;

			if (recordToAdd == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.Periode_Record'.", "record");
			}

			Params.spI_Periode Param = new Params.spI_Periode();
			Param.SetUpConnection(this.connectionString);

			Param.Param_Annee = recordToAdd.Col_Annee;
			Param.Param_SemaineNo = recordToAdd.Col_SemaineNo;
			Param.Param_DateDebut = recordToAdd.Col_DateDebut;
			Param.Param_DateFin = recordToAdd.Col_DateFin;
			Param.Param_PeriodeContingentement = recordToAdd.Col_PeriodeContingentement;

			SPs.spI_Periode Sp = new SPs.spI_Periode();
			if (Sp.Execute(ref Param)) {

				Periode_Record newRecord = new Periode_Record(this.connectionString, Param.Param_Annee, Param.Param_SemaineNo);				if (internalRecords != null) {

					internalRecords.Add(newRecord);
				}

				return(newRecord);
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Periode_Collection", "Add");
			}	
		}

		/// <param name="Col_Annee">[To be supplied.]</param>
		/// <param name="Col_SemaineNo">[To be supplied.]</param>
		public void Remove(System.Data.SqlTypes.SqlInt32 Col_Annee, System.Data.SqlTypes.SqlInt32 Col_SemaineNo) {
		
			Params.spD_Periode Param = new Params.spD_Periode(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_Annee = Col_Annee;

			Param.Param_SemaineNo = Col_SemaineNo;


			SPs.spD_Periode Sp = new SPs.spD_Periode(true);

			Sp.Execute(ref Param);
		}

		public void Remove(IBusinessComponentRecord record) {
		
			Periode_Record recordToDelete = record as Periode_Record;

			if (recordToDelete == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.Periode_Record'.", "record");
			}

			Params.spD_Periode Param = new Params.spD_Periode(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_Annee = recordToDelete.Col_Annee;

			Param.Param_SemaineNo = recordToDelete.Col_SemaineNo;


			SPs.spD_Periode Sp = new SPs.spD_Periode(true);

			Sp.Execute(ref Param);

			if (internalRecords != null) {

				internalRecords.Remove(recordToDelete);
			}
		}

		private System.Data.SqlTypes.SqlInt32 col_Annee = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_Annee
		{
			get 
			{

				return(this.col_Annee);
			}
			set 
			{

				this.col_Annee = value;
			}
		}

		public void Refresh() {

			internalRecords = new System.Collections.ArrayList();

			Params.spS_Periode_Display Param = new Params.spS_Periode_Display();
			Param.SetUpConnection(this.connectionString);

			if (!this.col_Annee.IsNull) 
			{
				Param.Param_Annee = this.col_Annee;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Periode_Display Sp = new SPs.spS_Periode_Display();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				while (sqlDataReader.Read()) {

					Periode_Record record = new Periode_Record(this.connectionString, sqlDataReader.GetSqlInt32(SPs.spS_Periode_Display.Resultset1.Fields.Column_ID1.ColumnIndex), sqlDataReader.GetSqlInt32(SPs.spS_Periode_Display.Resultset1.Fields.Column_ID2.ColumnIndex));

					record.displayName = "spS_Periode_Display";

					internalRecords.Add(record);
				}

				if (sqlDataReader != null && !sqlDataReader.IsClosed) {

					sqlDataReader.Close();
				}

				if (Sp.Connection != null && Sp.Connection.State == System.Data.ConnectionState.Open) {

					Sp.Connection.Close();
					Sp.Connection.Dispose();
				}

				this.recordsAreLoaded = true;
			}
			else {

				if (sqlDataReader != null && !sqlDataReader.IsClosed) {

					sqlDataReader.Close();
				}

				if (Sp.Connection != null && Sp.Connection.State == System.Data.ConnectionState.Open) {

					Sp.Connection.Close();
					Sp.Connection.Dispose();
				}

				this.recordsAreLoaded = false;
				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Periode_Collection", "Refresh");
			}
		}

		public System.Collections.IEnumerator GetEnumerator() {

			if (!this.recordsAreLoaded) {

				Refresh();
			}

			return(internalRecords.GetEnumerator());
		}

		public Periode_Record this[int index] {

			get {
				
				return((Periode_Record)internalRecords[index]);
			}
		}

		/// <param name="col_Annee">[To be supplied.]</param>
		/// <param name="col_SemaineNo">[To be supplied.]</param>
		/// <returns>[To be supplied.]</returns>
		public Periode_Record this[System.Data.SqlTypes.SqlInt32 col_Annee, System.Data.SqlTypes.SqlInt32 col_SemaineNo] {

			get {

				foreach(Periode_Record record in internalRecords) {

					bool Equality = true;

					Equality = Equality && (record.Col_Annee == col_Annee).Value;
					if (Equality) return(null);

					Equality = Equality && (record.Col_SemaineNo == col_SemaineNo).Value;
					if (Equality) return(null);

					return(record);
				}
				return(null);
			}
		}
	}
}
