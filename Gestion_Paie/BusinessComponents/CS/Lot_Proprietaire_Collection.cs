using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	public sealed class Lot_Proprietaire_Collection : IBusinessComponentCollection, System.Collections.IEnumerable, System.ComponentModel.IListSource {

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

		private System.Data.SqlTypes.SqlString col_ProprietaireID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_ProprietaireID {

			get {

				return(this.col_ProprietaireID);
			}
			set {

				this.col_ProprietaireID = value;
			}
		}

		internal void LoadFrom_ProprietaireID(System.Data.SqlTypes.SqlString col_ProprietaireID, Fournisseur_Record parent) {
		
			if (col_ProprietaireID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_ProprietaireID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_ProprietaireID = col_ProprietaireID;
			this.parent = parent;
		}

		private System.Data.SqlTypes.SqlInt32 col_LotID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_LotID {

			get {

				return(this.col_LotID);
			}
			set {

				this.col_LotID = value;
			}
		}

		internal void LoadFrom_LotID(System.Data.SqlTypes.SqlInt32 col_LotID, Lot_Record parent) {
		
			if (col_LotID.IsNull) {

				throw new ArgumentException("Parameter can not be null", "col_LotID");
			}

			if (parent == null) {

				throw new ArgumentException("Parameter can not be null", "parent");
			}

			this.col_LotID = col_LotID;
			this.parent = parent;
		}


		public Lot_Proprietaire_Collection(string connectionString) {
			
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'Lot_Proprietaire'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "Lot_Proprietaire", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

		}


		public IBusinessComponentRecord Add(IBusinessComponentRecord record) {
		
			Lot_Proprietaire_Record recordToAdd = record as Lot_Proprietaire_Record;

			if (recordToAdd == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.Lot_Proprietaire_Record'.", "record");
			}

			Params.spI_Lot_Proprietaire Param = new Params.spI_Lot_Proprietaire();
			Param.SetUpConnection(this.connectionString);

			Param.Param_ProprietaireID = recordToAdd.Col_ProprietaireID;
			Param.Param_DateDebut = recordToAdd.Col_DateDebut;
			Param.Param_DateFin = recordToAdd.Col_DateFin;
			Param.Param_LotID = recordToAdd.Col_LotID;

			SPs.spI_Lot_Proprietaire Sp = new SPs.spI_Lot_Proprietaire();
			if (Sp.Execute(ref Param)) {

				Lot_Proprietaire_Record newRecord = new Lot_Proprietaire_Record(this.connectionString, Param.Param_ProprietaireID, Param.Param_DateDebut, Param.Param_LotID);				if (internalRecords != null) {

					internalRecords.Add(newRecord);
				}

				return(newRecord);
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Lot_Proprietaire_Collection", "Add");
			}	
		}

		/// <param name="Col_ProprietaireID">[To be supplied.]</param>
		/// <param name="Col_DateDebut">[To be supplied.]</param>
		/// <param name="Col_LotID">[To be supplied.]</param>
		public void Remove(System.Data.SqlTypes.SqlString Col_ProprietaireID, System.Data.SqlTypes.SqlDateTime Col_DateDebut, System.Data.SqlTypes.SqlInt32 Col_LotID) {
		
			Params.spD_Lot_Proprietaire Param = new Params.spD_Lot_Proprietaire(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_ProprietaireID = Col_ProprietaireID;

			Param.Param_DateDebut = Col_DateDebut;

			Param.Param_LotID = Col_LotID;


			SPs.spD_Lot_Proprietaire Sp = new SPs.spD_Lot_Proprietaire(true);

			Sp.Execute(ref Param);
		}

		public void Remove(IBusinessComponentRecord record) {
		
			Lot_Proprietaire_Record recordToDelete = record as Lot_Proprietaire_Record;

			if (recordToDelete == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.Lot_Proprietaire_Record'.", "record");
			}

			Params.spD_Lot_Proprietaire Param = new Params.spD_Lot_Proprietaire(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_ProprietaireID = recordToDelete.Col_ProprietaireID;

			Param.Param_DateDebut = recordToDelete.Col_DateDebut;

			Param.Param_LotID = recordToDelete.Col_LotID;


			SPs.spD_Lot_Proprietaire Sp = new SPs.spD_Lot_Proprietaire(true);

			Sp.Execute(ref Param);

			if (internalRecords != null) {

				internalRecords.Remove(recordToDelete);
			}
		}

		public void Refresh() {

			internalRecords = new System.Collections.ArrayList();

			Params.spS_Lot_Proprietaire_Display Param = new Params.spS_Lot_Proprietaire_Display();
			Param.SetUpConnection(this.connectionString);

			if (!this.col_ProprietaireID.IsNull) {

				Param.Param_ProprietaireID = this.col_ProprietaireID;
			}

			if (!this.col_LotID.IsNull) {

				Param.Param_LotID = this.col_LotID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_Lot_Proprietaire_Display Sp = new SPs.spS_Lot_Proprietaire_Display();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				while (sqlDataReader.Read()) {

					Lot_Proprietaire_Record record = new Lot_Proprietaire_Record(this.connectionString, sqlDataReader.GetSqlString(SPs.spS_Lot_Proprietaire_Display.Resultset1.Fields.Column_ID1.ColumnIndex), sqlDataReader.GetSqlDateTime(SPs.spS_Lot_Proprietaire_Display.Resultset1.Fields.Column_ID2.ColumnIndex), sqlDataReader.GetSqlInt32(SPs.spS_Lot_Proprietaire_Display.Resultset1.Fields.Column_ID3.ColumnIndex));

					record.displayName = "spS_Lot_Proprietaire_Display";

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
				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.Lot_Proprietaire_Collection", "Refresh");
			}
		}

		public System.Collections.IEnumerator GetEnumerator() {

			if (!this.recordsAreLoaded) {

				Refresh();
			}

			return(internalRecords.GetEnumerator());
		}

		public Lot_Proprietaire_Record this[int index] {

			get {
				
				return((Lot_Proprietaire_Record)internalRecords[index]);
			}
		}

		/// <param name="col_ProprietaireID">[To be supplied.]</param>
		/// <param name="col_DateDebut">[To be supplied.]</param>
		/// <param name="col_LotID">[To be supplied.]</param>
		/// <returns>[To be supplied.]</returns>
		public Lot_Proprietaire_Record this[System.Data.SqlTypes.SqlString col_ProprietaireID, System.Data.SqlTypes.SqlDateTime col_DateDebut, System.Data.SqlTypes.SqlInt32 col_LotID] {

			get {

				foreach(Lot_Proprietaire_Record record in internalRecords) {

					bool Equality = true;

					Equality = Equality && (record.Col_ProprietaireID == col_ProprietaireID).Value;
					if (Equality) return(null);

					Equality = Equality && (record.Col_DateDebut == col_DateDebut).Value;
					if (Equality) return(null);

					Equality = Equality && (record.Col_LotID == col_LotID).Value;
					if (Equality) return(null);

					return(record);
				}
				return(null);
			}
		}
	}
}
