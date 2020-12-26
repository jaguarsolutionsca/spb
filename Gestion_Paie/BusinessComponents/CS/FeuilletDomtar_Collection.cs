using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	public sealed class FeuilletDomtar_Collection : IBusinessComponentCollection, System.Collections.IEnumerable, System.ComponentModel.IListSource {

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


		public FeuilletDomtar_Collection(string connectionString) {
			
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
				sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'FeuilletDomtar'";

				int CurrentRevision = (int)sqlCommand.ExecuteScalar();

				sqlConnection.Close();

				int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
				if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "FeuilletDomtar", CurrentRevision, OriginalRevision));
				}
			}
			}
#endif

		}


		public IBusinessComponentRecord Add(IBusinessComponentRecord record) {
		
			FeuilletDomtar_Record recordToAdd = record as FeuilletDomtar_Record;

			if (recordToAdd == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.FeuilletDomtar_Record'.", "record");
			}

			Params.spI_FeuilletDomtar Param = new Params.spI_FeuilletDomtar();
			Param.SetUpConnection(this.connectionString);

			Param.Param_Transaction = recordToAdd.Col_Transaction;
			Param.Param_TransactionType = recordToAdd.Col_TransactionType;
			Param.Param_Fournisseur = recordToAdd.Col_Fournisseur;
			Param.Param_Contrat = recordToAdd.Col_Contrat;
			Param.Param_Produit = recordToAdd.Col_Produit;
			Param.Param_DateLivraison = recordToAdd.Col_DateLivraison;
			Param.Param_Carte = recordToAdd.Col_Carte;
			Param.Param_License = recordToAdd.Col_License;
			Param.Param_Transporteur_Camion = recordToAdd.Col_Transporteur_Camion;
			Param.Param_Producteur = recordToAdd.Col_Producteur;
			Param.Param_Municipalite = recordToAdd.Col_Municipalite;
			Param.Param_Brut = recordToAdd.Col_Brut;
			Param.Param_Tare = recordToAdd.Col_Tare;
			Param.Param_Net = recordToAdd.Col_Net;
			Param.Param_Rejets = recordToAdd.Col_Rejets;
			Param.Param_KgVert_Paye = recordToAdd.Col_KgVert_Paye;
			Param.Param_Pourcent_Sec = recordToAdd.Col_Pourcent_Sec;
			Param.Param_KgSec_Paye = recordToAdd.Col_KgSec_Paye;
			Param.Param_Validation = recordToAdd.Col_Validation;
			Param.Param_Transfert = recordToAdd.Col_Transfert;
			Param.Param_EssenceID = recordToAdd.Col_EssenceID;
			Param.Param_UniteID = recordToAdd.Col_UniteID;
			Param.Param_Code = recordToAdd.Col_Code;
			Param.Param_TransporteurID = recordToAdd.Col_TransporteurID;
			Param.Param_BonCommande = recordToAdd.Col_BonCommande;

			SPs.spI_FeuilletDomtar Sp = new SPs.spI_FeuilletDomtar();
			if (Sp.Execute(ref Param)) {

				FeuilletDomtar_Record newRecord = new FeuilletDomtar_Record(this.connectionString, Param.Param_Transaction);				if (internalRecords != null) {

					internalRecords.Add(newRecord);
				}

				return(newRecord);
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.FeuilletDomtar_Collection", "Add");
			}	
		}

		/// <param name="Col_Transaction">[To be supplied.]</param>
		public void Remove(System.Data.SqlTypes.SqlString Col_Transaction) {
		
			Params.spD_FeuilletDomtar Param = new Params.spD_FeuilletDomtar(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_Transaction = Col_Transaction;


			SPs.spD_FeuilletDomtar Sp = new SPs.spD_FeuilletDomtar(true);

			Sp.Execute(ref Param);
		}

		public void Remove(IBusinessComponentRecord record) {
		
			FeuilletDomtar_Record recordToDelete = record as FeuilletDomtar_Record;

			if (recordToDelete == null) {

				throw new ArgumentException("Invalid record type. Must be 'Gestion_Paie.BusinessComponents.FeuilletDomtar_Record'.", "record");
			}

			Params.spD_FeuilletDomtar Param = new Params.spD_FeuilletDomtar(true);
			Param.SetUpConnection(this.connectionString);

			Param.Param_Transaction = recordToDelete.Col_Transaction;


			SPs.spD_FeuilletDomtar Sp = new SPs.spD_FeuilletDomtar(true);

			Sp.Execute(ref Param);

			if (internalRecords != null) {

				internalRecords.Remove(recordToDelete);
			}
		}

		public void Refresh() {

			internalRecords = new System.Collections.ArrayList();

			Params.spS_FeuilletDomtar_Display Param = new Params.spS_FeuilletDomtar_Display();
			Param.SetUpConnection(this.connectionString);


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_FeuilletDomtar_Display Sp = new SPs.spS_FeuilletDomtar_Display();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				while (sqlDataReader.Read()) {

					FeuilletDomtar_Record record = new FeuilletDomtar_Record(this.connectionString, sqlDataReader.GetSqlString(SPs.spS_FeuilletDomtar_Display.Resultset1.Fields.Column_ID1.ColumnIndex));

					record.displayName = "spS_FeuilletDomtar_Display";

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
				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.FeuilletDomtar_Collection", "Refresh");
			}
		}

		public System.Collections.IEnumerator GetEnumerator() {

			if (!this.recordsAreLoaded) {

				Refresh();
			}

			return(internalRecords.GetEnumerator());
		}

		public FeuilletDomtar_Record this[int index] {

			get {
				
				return((FeuilletDomtar_Record)internalRecords[index]);
			}
		}

		/// <param name="col_Transaction">[To be supplied.]</param>
		/// <returns>[To be supplied.]</returns>
		public FeuilletDomtar_Record this[System.Data.SqlTypes.SqlString col_Transaction] {

			get {

				foreach(FeuilletDomtar_Record record in internalRecords) {

					bool Equality = true;

					Equality = Equality && (record.Col_Transaction == col_Transaction).Value;
					if (Equality) return(null);

					return(record);
				}
				return(null);
			}
		}
	}
}
