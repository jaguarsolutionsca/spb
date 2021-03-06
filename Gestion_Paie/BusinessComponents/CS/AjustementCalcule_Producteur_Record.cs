﻿using System;
using Params = Gestion_Paie.DataClasses.Parameters;
using SPs = Gestion_Paie.DataClasses.StoredProcedures;

namespace Gestion_Paie.BusinessComponents {

	/// <summary>
	/// This class is an abstract class that represents the [AjustementCalcule_Producteur] table. With this class
	/// you can load or update a record from the database. If you need to add or delete a record,
	/// you must use the <see cref="Gestion_Paie.BusinessComponents.AjustementCalcule_Producteur_Collection"/> class to do so.
	/// </summary>
	public sealed class AjustementCalcule_Producteur_Record : IBusinessComponentRecord {
	
		internal bool recordWasLoadedFromDB = false;
		private bool recordIsLoaded = false;

		internal string connectionString = String.Empty;
		public string ConnectionString {
		
			get {
			
				return(this.connectionString);
			}
		}
		
		/// <summary>
		/// Initializes a new instance of the AjustementCalcule_Producteur_Record class. Use this contructor to add
		/// a new record. Then call the Add method of the Gestion_Paie.BusinessComponents.AjustementCalcule_Producteur_Collection class to actually
		/// add the record in the database.
		/// </summary>
		public AjustementCalcule_Producteur_Record() {
		
			this.recordWasLoadedFromDB = false;
			this.recordIsLoaded = false;
		}
	
		/// <param name="col_ID">[To be supplied.]</param>
		public AjustementCalcule_Producteur_Record(string connectionString, System.Data.SqlTypes.SqlInt32 col_ID) {

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
					sqlCommand.CommandText = "Select sysobjects.schema_ver from sysobjects where sysobjects.name = 'AjustementCalcule_Producteur'";

					int CurrentRevision = (int)sqlCommand.ExecuteScalar();

					sqlConnection.Close();

					int OriginalRevision = ((Gestion_Paie.DataClasses.OlymarsInformationAttribute)System.Attribute.GetCustomAttribute(this.GetType(), typeof(Gestion_Paie.DataClasses.OlymarsInformationAttribute), false)).SqlObjectDependancyRevision;
					if (CurrentRevision != OriginalRevision) {

					throw new System.InvalidOperationException(System.String.Format("OLYMARS: This code is not in sync anymore with [{0}]. It was generated when [{0}] version was: {2}. Current [{0}] version is: {1}", "AjustementCalcule_Producteur", CurrentRevision, OriginalRevision));
					}
				}
			}
#endif

			this.recordWasLoadedFromDB = true;
			this.recordIsLoaded = false;
			this.connectionString = connectionString;
			this.col_ID = col_ID;
		}
		
		internal System.Data.SqlTypes.SqlInt32 col_ID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_ID {
		
			get {
			
				return(this.col_ID);
			}

			set {

				if (this.recordWasLoadedFromDB) {

					throw new System.Exception("You cannot affect this primary key since the record was loaded from the database.");
				}
				else {

					this.col_ID = value;
				}
			}
		}
		
		internal bool col_DateCalculWasSet = false;
		private bool col_DateCalculWasUpdated = false;
		internal System.Data.SqlTypes.SqlDateTime col_DateCalcul = System.Data.SqlTypes.SqlDateTime.Null;
		public System.Data.SqlTypes.SqlDateTime Col_DateCalcul {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_DateCalcul);
			}
			set {
			
				this.col_DateCalculWasUpdated = true;
				this.col_DateCalculWasSet = true;
				this.col_DateCalcul = value;
			}
		}

		internal bool col_AjustementIDWasSet = false;
		private bool col_AjustementIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_AjustementID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_AjustementID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_AjustementID);
			}
			set {
			
				this.col_AjustementIDWasUpdated = true;
				this.col_AjustementIDWasSet = true;
				this.col_AjustementID_Record = null;
				this.col_AjustementID = value;
			}
		}

		
		private Ajustement_EssenceUnite_Record col_AjustementID_Record = null;
		public Ajustement_EssenceUnite_Record Col_AjustementID_Ajustement_EssenceUnite_Record {
		
			get {

				if (this.col_AjustementID_Record == null) {
				
					this.col_AjustementID_Record = new Ajustement_EssenceUnite_Record(this.connectionString, this.col_AjustementID, System.Data.SqlTypes.SqlString.Null, System.Data.SqlTypes.SqlString.Null, System.Data.SqlTypes.SqlString.Null);
				}
				
				return(this.col_AjustementID_Record);
			}
		}

		internal bool col_EssenceIDWasSet = false;
		private bool col_EssenceIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_EssenceID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_EssenceID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_EssenceID);
			}
			set {
			
				this.col_EssenceIDWasUpdated = true;
				this.col_EssenceIDWasSet = true;
				this.col_EssenceID_Record = null;
				this.col_EssenceID = value;
			}
		}

		
		private Ajustement_EssenceUnite_Record col_EssenceID_Record = null;
		public Ajustement_EssenceUnite_Record Col_EssenceID_Ajustement_EssenceUnite_Record {
		
			get {

				if (this.col_EssenceID_Record == null) {
				
					this.col_EssenceID_Record = new Ajustement_EssenceUnite_Record(this.connectionString, System.Data.SqlTypes.SqlInt32.Null, this.col_EssenceID, System.Data.SqlTypes.SqlString.Null, System.Data.SqlTypes.SqlString.Null);
				}
				
				return(this.col_EssenceID_Record);
			}
		}

		internal bool col_UniteIDWasSet = false;
		private bool col_UniteIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_UniteID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_UniteID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_UniteID);
			}
			set {
			
				this.col_UniteIDWasUpdated = true;
				this.col_UniteIDWasSet = true;
				this.col_UniteID_Record = null;
				this.col_UniteID = value;
			}
		}

		
		private Ajustement_EssenceUnite_Record col_UniteID_Record = null;
		public Ajustement_EssenceUnite_Record Col_UniteID_Ajustement_EssenceUnite_Record {
		
			get {

				if (this.col_UniteID_Record == null) {
				
					this.col_UniteID_Record = new Ajustement_EssenceUnite_Record(this.connectionString, System.Data.SqlTypes.SqlInt32.Null, System.Data.SqlTypes.SqlString.Null, this.col_UniteID, System.Data.SqlTypes.SqlString.Null);
				}
				
				return(this.col_UniteID_Record);
			}
		}

		internal bool col_LivraisonDetailIDWasSet = false;
		private bool col_LivraisonDetailIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_LivraisonDetailID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_LivraisonDetailID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_LivraisonDetailID);
			}
			set {
			
				this.col_LivraisonDetailIDWasUpdated = true;
				this.col_LivraisonDetailIDWasSet = true;
				this.col_LivraisonDetailID_Record = null;
				this.col_LivraisonDetailID = value;
			}
		}

		
		private Livraison_Detail_Record col_LivraisonDetailID_Record = null;
		public Livraison_Detail_Record Col_LivraisonDetailID_Livraison_Detail_Record {
		
			get {

				if (this.col_LivraisonDetailID_Record == null) {
				
					this.col_LivraisonDetailID_Record = new Livraison_Detail_Record(this.connectionString, this.col_LivraisonDetailID);
				}
				
				return(this.col_LivraisonDetailID_Record);
			}
		}

		internal bool col_ProducteurIDWasSet = false;
		private bool col_ProducteurIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_ProducteurID = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_ProducteurID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_ProducteurID);
			}
			set {
			
				this.col_ProducteurIDWasUpdated = true;
				this.col_ProducteurIDWasSet = true;
				this.col_ProducteurID_Record = null;
				this.col_ProducteurID = value;
			}
		}

		
		private Fournisseur_Record col_ProducteurID_Record = null;
		public Fournisseur_Record Col_ProducteurID_Fournisseur_Record {
		
			get {

				if (this.col_ProducteurID_Record == null) {
				
					this.col_ProducteurID_Record = new Fournisseur_Record(this.connectionString, this.col_ProducteurID);
				}
				
				return(this.col_ProducteurID_Record);
			}
		}

		internal bool col_VolumeWasSet = false;
		private bool col_VolumeWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Volume = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Volume {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Volume);
			}
			set {
			
				this.col_VolumeWasUpdated = true;
				this.col_VolumeWasSet = true;
				this.col_Volume = value;
			}
		}

		internal bool col_TauxWasSet = false;
		private bool col_TauxWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Taux = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Taux {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Taux);
			}
			set {
			
				this.col_TauxWasUpdated = true;
				this.col_TauxWasSet = true;
				this.col_Taux = value;
			}
		}

		internal bool col_MontantWasSet = false;
		private bool col_MontantWasUpdated = false;
		internal System.Data.SqlTypes.SqlDouble col_Montant = System.Data.SqlTypes.SqlDouble.Null;
		public System.Data.SqlTypes.SqlDouble Col_Montant {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Montant);
			}
			set {
			
				this.col_MontantWasUpdated = true;
				this.col_MontantWasSet = true;
				this.col_Montant = value;
			}
		}

		internal bool col_FactureWasSet = false;
		private bool col_FactureWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_Facture = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_Facture {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Facture);
			}
			set {
			
				this.col_FactureWasUpdated = true;
				this.col_FactureWasSet = true;
				this.col_Facture = value;
			}
		}

		internal bool col_FactureIDWasSet = false;
		private bool col_FactureIDWasUpdated = false;
		internal System.Data.SqlTypes.SqlInt32 col_FactureID = System.Data.SqlTypes.SqlInt32.Null;
		public System.Data.SqlTypes.SqlInt32 Col_FactureID {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_FactureID);
			}
			set {
			
				this.col_FactureIDWasUpdated = true;
				this.col_FactureIDWasSet = true;
				this.col_FactureID_Record = null;
				this.col_FactureID = value;
			}
		}

		
		private FactureFournisseur_Record col_FactureID_Record = null;
		public FactureFournisseur_Record Col_FactureID_FactureFournisseur_Record {
		
			get {

				if (this.col_FactureID_Record == null) {
				
					this.col_FactureID_Record = new FactureFournisseur_Record(this.connectionString, this.col_FactureID);
				}
				
				return(this.col_FactureID_Record);
			}
		}

		internal bool col_ErreurCalculWasSet = false;
		private bool col_ErreurCalculWasUpdated = false;
		internal System.Data.SqlTypes.SqlBoolean col_ErreurCalcul = System.Data.SqlTypes.SqlBoolean.Null;
		public System.Data.SqlTypes.SqlBoolean Col_ErreurCalcul {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_ErreurCalcul);
			}
			set {
			
				this.col_ErreurCalculWasUpdated = true;
				this.col_ErreurCalculWasSet = true;
				this.col_ErreurCalcul = value;
			}
		}

		internal bool col_ErreurDescriptionWasSet = false;
		private bool col_ErreurDescriptionWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_ErreurDescription = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_ErreurDescription {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_ErreurDescription);
			}
			set {
			
				this.col_ErreurDescriptionWasUpdated = true;
				this.col_ErreurDescriptionWasSet = true;
				this.col_ErreurDescription = value;
			}
		}

		internal bool col_CodeWasSet = false;
		private bool col_CodeWasUpdated = false;
		internal System.Data.SqlTypes.SqlString col_Code = System.Data.SqlTypes.SqlString.Null;
		public System.Data.SqlTypes.SqlString Col_Code {
		
			get {
			
				if (this.recordWasLoadedFromDB && !this.recordIsLoaded) {

					Refresh();
				}
				return(this.col_Code);
			}
			set {
			
				this.col_CodeWasUpdated = true;
				this.col_CodeWasSet = true;
				this.col_Code_Record = null;
				this.col_Code = value;
			}
		}

		
		private Ajustement_EssenceUnite_Record col_Code_Record = null;
		public Ajustement_EssenceUnite_Record Col_Code_Ajustement_EssenceUnite_Record {
		
			get {

				if (this.col_Code_Record == null) {
				
					this.col_Code_Record = new Ajustement_EssenceUnite_Record(this.connectionString, System.Data.SqlTypes.SqlInt32.Null, System.Data.SqlTypes.SqlString.Null, System.Data.SqlTypes.SqlString.Null, this.col_Code);
				}
				
				return(this.col_Code_Record);
			}
		}


		public bool Refresh() {

			this.displayName = null;

			this.col_DateCalculWasUpdated = false;
			this.col_DateCalculWasSet = false;
			this.col_DateCalcul = System.Data.SqlTypes.SqlDateTime.Null;

			this.col_AjustementIDWasUpdated = false;
			this.col_AjustementIDWasSet = false;
			this.col_AjustementID = System.Data.SqlTypes.SqlInt32.Null;

			this.col_EssenceIDWasUpdated = false;
			this.col_EssenceIDWasSet = false;
			this.col_EssenceID = System.Data.SqlTypes.SqlString.Null;

			this.col_UniteIDWasUpdated = false;
			this.col_UniteIDWasSet = false;
			this.col_UniteID = System.Data.SqlTypes.SqlString.Null;

			this.col_LivraisonDetailIDWasUpdated = false;
			this.col_LivraisonDetailIDWasSet = false;
			this.col_LivraisonDetailID = System.Data.SqlTypes.SqlInt32.Null;

			this.col_ProducteurIDWasUpdated = false;
			this.col_ProducteurIDWasSet = false;
			this.col_ProducteurID = System.Data.SqlTypes.SqlString.Null;

			this.col_VolumeWasUpdated = false;
			this.col_VolumeWasSet = false;
			this.col_Volume = System.Data.SqlTypes.SqlDouble.Null;

			this.col_TauxWasUpdated = false;
			this.col_TauxWasSet = false;
			this.col_Taux = System.Data.SqlTypes.SqlDouble.Null;

			this.col_MontantWasUpdated = false;
			this.col_MontantWasSet = false;
			this.col_Montant = System.Data.SqlTypes.SqlDouble.Null;

			this.col_FactureWasUpdated = false;
			this.col_FactureWasSet = false;
			this.col_Facture = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_FactureIDWasUpdated = false;
			this.col_FactureIDWasSet = false;
			this.col_FactureID = System.Data.SqlTypes.SqlInt32.Null;

			this.col_ErreurCalculWasUpdated = false;
			this.col_ErreurCalculWasSet = false;
			this.col_ErreurCalcul = System.Data.SqlTypes.SqlBoolean.Null;

			this.col_ErreurDescriptionWasUpdated = false;
			this.col_ErreurDescriptionWasSet = false;
			this.col_ErreurDescription = System.Data.SqlTypes.SqlString.Null;

			this.col_CodeWasUpdated = false;
			this.col_CodeWasSet = false;
			this.col_Code = System.Data.SqlTypes.SqlString.Null;

			Params.spS_AjustementCalcule_Producteur Param = new Params.spS_AjustementCalcule_Producteur(true);
			Param.SetUpConnection(this.connectionString);

			if (!this.col_ID.IsNull) {

				Param.Param_ID = this.col_ID;
			}


			System.Data.SqlClient.SqlDataReader sqlDataReader = null;
			SPs.spS_AjustementCalcule_Producteur Sp = new SPs.spS_AjustementCalcule_Producteur();
			if (Sp.Execute(ref Param, out sqlDataReader)) {

				if (sqlDataReader.Read()) {

					if (!sqlDataReader.IsDBNull(SPs.spS_AjustementCalcule_Producteur.Resultset1.Fields.Column_DateCalcul.ColumnIndex)) {

						this.col_DateCalcul = sqlDataReader.GetSqlDateTime(SPs.spS_AjustementCalcule_Producteur.Resultset1.Fields.Column_DateCalcul.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_AjustementCalcule_Producteur.Resultset1.Fields.Column_AjustementID.ColumnIndex)) {

						this.col_AjustementID = sqlDataReader.GetSqlInt32(SPs.spS_AjustementCalcule_Producteur.Resultset1.Fields.Column_AjustementID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_AjustementCalcule_Producteur.Resultset1.Fields.Column_EssenceID.ColumnIndex)) {

						this.col_EssenceID = sqlDataReader.GetSqlString(SPs.spS_AjustementCalcule_Producteur.Resultset1.Fields.Column_EssenceID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_AjustementCalcule_Producteur.Resultset1.Fields.Column_UniteID.ColumnIndex)) {

						this.col_UniteID = sqlDataReader.GetSqlString(SPs.spS_AjustementCalcule_Producteur.Resultset1.Fields.Column_UniteID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_AjustementCalcule_Producteur.Resultset1.Fields.Column_LivraisonDetailID.ColumnIndex)) {

						this.col_LivraisonDetailID = sqlDataReader.GetSqlInt32(SPs.spS_AjustementCalcule_Producteur.Resultset1.Fields.Column_LivraisonDetailID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_AjustementCalcule_Producteur.Resultset1.Fields.Column_ProducteurID.ColumnIndex)) {

						this.col_ProducteurID = sqlDataReader.GetSqlString(SPs.spS_AjustementCalcule_Producteur.Resultset1.Fields.Column_ProducteurID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_AjustementCalcule_Producteur.Resultset1.Fields.Column_Volume.ColumnIndex)) {

						this.col_Volume = sqlDataReader.GetSqlDouble(SPs.spS_AjustementCalcule_Producteur.Resultset1.Fields.Column_Volume.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_AjustementCalcule_Producteur.Resultset1.Fields.Column_Taux.ColumnIndex)) {

						this.col_Taux = sqlDataReader.GetSqlDouble(SPs.spS_AjustementCalcule_Producteur.Resultset1.Fields.Column_Taux.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_AjustementCalcule_Producteur.Resultset1.Fields.Column_Montant.ColumnIndex)) {

						this.col_Montant = sqlDataReader.GetSqlDouble(SPs.spS_AjustementCalcule_Producteur.Resultset1.Fields.Column_Montant.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_AjustementCalcule_Producteur.Resultset1.Fields.Column_Facture.ColumnIndex)) {

						this.col_Facture = sqlDataReader.GetSqlBoolean(SPs.spS_AjustementCalcule_Producteur.Resultset1.Fields.Column_Facture.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_AjustementCalcule_Producteur.Resultset1.Fields.Column_FactureID.ColumnIndex)) {

						this.col_FactureID = sqlDataReader.GetSqlInt32(SPs.spS_AjustementCalcule_Producteur.Resultset1.Fields.Column_FactureID.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_AjustementCalcule_Producteur.Resultset1.Fields.Column_ErreurCalcul.ColumnIndex)) {

						this.col_ErreurCalcul = sqlDataReader.GetSqlBoolean(SPs.spS_AjustementCalcule_Producteur.Resultset1.Fields.Column_ErreurCalcul.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_AjustementCalcule_Producteur.Resultset1.Fields.Column_ErreurDescription.ColumnIndex)) {

						this.col_ErreurDescription = sqlDataReader.GetSqlString(SPs.spS_AjustementCalcule_Producteur.Resultset1.Fields.Column_ErreurDescription.ColumnIndex);
					}
					if (!sqlDataReader.IsDBNull(SPs.spS_AjustementCalcule_Producteur.Resultset1.Fields.Column_Code.ColumnIndex)) {

						this.col_Code = sqlDataReader.GetSqlString(SPs.spS_AjustementCalcule_Producteur.Resultset1.Fields.Column_Code.ColumnIndex);
					}

					if (sqlDataReader != null && !sqlDataReader.IsClosed) {

						sqlDataReader.Close();
					}

					if (Sp.Connection != null && Sp.Connection.State == System.Data.ConnectionState.Open) {

						Sp.Connection.Close();
						Sp.Connection.Dispose();
					}

					this.recordIsLoaded = true;

					return(true);
				}
				else {

					if (sqlDataReader != null && !sqlDataReader.IsClosed) {

						sqlDataReader.Close();
					}

					if (Sp.Connection != null && Sp.Connection.State == System.Data.ConnectionState.Open) {

						Sp.Connection.Close();
						Sp.Connection.Dispose();
					}

					this.recordIsLoaded = false;

					return(false);
				}
			}
			else {

				if (sqlDataReader != null && !sqlDataReader.IsClosed) {

					sqlDataReader.Close();
				}

				if (Sp.Connection != null && Sp.Connection.State == System.Data.ConnectionState.Open) {

					Sp.Connection.Close();
					Sp.Connection.Dispose();
				}

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.AjustementCalcule_Producteur_Record", "Refresh");
			}
		}

		public void Update() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. No update is possible.");
			}

			bool ChangesHaveBeenMade = false;

			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_DateCalculWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_AjustementIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_EssenceIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_UniteIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_LivraisonDetailIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ProducteurIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_VolumeWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_TauxWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_MontantWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_FactureWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_FactureIDWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ErreurCalculWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_ErreurDescriptionWasUpdated);
			ChangesHaveBeenMade = (ChangesHaveBeenMade || col_CodeWasUpdated);

			if (!ChangesHaveBeenMade) {

				return;
			}

			Params.spU_AjustementCalcule_Producteur Param = new Params.spU_AjustementCalcule_Producteur(false);
			Param.SetUpConnection(this.connectionString);
			Param.Param_ID = this.col_ID;

			if (this.col_DateCalculWasUpdated) {

				Param.Param_DateCalcul = this.col_DateCalcul;
				Param.Param_ConsiderNull_DateCalcul = true;
			}

			if (this.col_AjustementIDWasUpdated) {

				Param.Param_AjustementID = this.col_AjustementID;
				Param.Param_ConsiderNull_AjustementID = true;
			}

			if (this.col_EssenceIDWasUpdated) {

				Param.Param_EssenceID = this.col_EssenceID;
				Param.Param_ConsiderNull_EssenceID = true;
			}

			if (this.col_UniteIDWasUpdated) {

				Param.Param_UniteID = this.col_UniteID;
				Param.Param_ConsiderNull_UniteID = true;
			}

			if (this.col_LivraisonDetailIDWasUpdated) {

				Param.Param_LivraisonDetailID = this.col_LivraisonDetailID;
				Param.Param_ConsiderNull_LivraisonDetailID = true;
			}

			if (this.col_ProducteurIDWasUpdated) {

				Param.Param_ProducteurID = this.col_ProducteurID;
				Param.Param_ConsiderNull_ProducteurID = true;
			}

			if (this.col_VolumeWasUpdated) {

				Param.Param_Volume = this.col_Volume;
				Param.Param_ConsiderNull_Volume = true;
			}

			if (this.col_TauxWasUpdated) {

				Param.Param_Taux = this.col_Taux;
				Param.Param_ConsiderNull_Taux = true;
			}

			if (this.col_MontantWasUpdated) {

				Param.Param_Montant = this.col_Montant;
				Param.Param_ConsiderNull_Montant = true;
			}

			if (this.col_FactureWasUpdated) {

				Param.Param_Facture = this.col_Facture;
				Param.Param_ConsiderNull_Facture = true;
			}

			if (this.col_FactureIDWasUpdated) {

				Param.Param_FactureID = this.col_FactureID;
				Param.Param_ConsiderNull_FactureID = true;
			}

			if (this.col_ErreurCalculWasUpdated) {

				Param.Param_ErreurCalcul = this.col_ErreurCalcul;
				Param.Param_ConsiderNull_ErreurCalcul = true;
			}

			if (this.col_ErreurDescriptionWasUpdated) {

				Param.Param_ErreurDescription = this.col_ErreurDescription;
				Param.Param_ConsiderNull_ErreurDescription = true;
			}

			if (this.col_CodeWasUpdated) {

				Param.Param_Code = this.col_Code;
				Param.Param_ConsiderNull_Code = true;
			}

			SPs.spU_AjustementCalcule_Producteur Sp = new SPs.spU_AjustementCalcule_Producteur();
			if (Sp.Execute(ref Param)) {

				this.col_DateCalculWasUpdated = false;
				this.col_AjustementIDWasUpdated = false;
				this.col_EssenceIDWasUpdated = false;
				this.col_UniteIDWasUpdated = false;
				this.col_LivraisonDetailIDWasUpdated = false;
				this.col_ProducteurIDWasUpdated = false;
				this.col_VolumeWasUpdated = false;
				this.col_TauxWasUpdated = false;
				this.col_MontantWasUpdated = false;
				this.col_FactureWasUpdated = false;
				this.col_FactureIDWasUpdated = false;
				this.col_ErreurCalculWasUpdated = false;
				this.col_ErreurDescriptionWasUpdated = false;
				this.col_CodeWasUpdated = false;
			}
			else {

				throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.AjustementCalcule_Producteur_Record", "Update");
			}		
		}

		internal string displayName = null;
		public override string ToString() {

			if (!this.recordWasLoadedFromDB) {

				throw new ArgumentException("No record was loaded from the database. The DisplayName is not available.");
			}
		
			if (this.displayName == null) {
			
				Params.spS_AjustementCalcule_Producteur_Display Param = new Params.spS_AjustementCalcule_Producteur_Display();
				Param.SetUpConnection(this.connectionString);

				Param.Param_ID = this.col_ID;

				System.Data.SqlClient.SqlDataReader sqlDataReader = null;
				SPs.spS_AjustementCalcule_Producteur_Display Sp = new SPs.spS_AjustementCalcule_Producteur_Display();
				if (Sp.Execute(ref Param, out sqlDataReader)) {

					if (sqlDataReader.Read()) {

						if (!sqlDataReader.IsDBNull(SPs.spS_AjustementCalcule_Producteur_Display.Resultset1.Fields.Column_Display.ColumnIndex)) {

							this.displayName = "spS_AjustementCalcule_Producteur_Display";
						}
					}

					if (sqlDataReader != null && !sqlDataReader.IsClosed) {

						sqlDataReader.Close();
					}

					if (Sp.Connection != null && Sp.Connection.State == System.Data.ConnectionState.Open) {

						Sp.Connection.Close();
						Sp.Connection.Dispose();
					}

				}
				else {

					if (sqlDataReader != null && !sqlDataReader.IsClosed) {

						sqlDataReader.Close();
					}

					if (Sp.Connection != null && Sp.Connection.State == System.Data.ConnectionState.Open) {

						Sp.Connection.Close();
						Sp.Connection.Dispose();
					}

					throw new Gestion_Paie.DataClasses.CustomException(Param, "Gestion_Paie.BusinessComponents.AjustementCalcule_Producteur_Record", "ToString");
				}				
			}
			
			return(this.displayName);
		}
	}
}
