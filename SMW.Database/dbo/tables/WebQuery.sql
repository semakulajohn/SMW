CREATE TABLE [dbo].[WebQuery]
(
	[WebQueryId] 	BIGINT IDENTITY(1,1) NOT NULL,		 
	[Body]		NVARCHAR(MAX) NOT NULL,
	[PhoneNumber]		NVARCHAR(MAX) NOT NULL,
	[Name]		NVARCHAR(50) NOT NULL,
	[EmailAddress]  NVARCHAR(50) NOT NULL,	
	[CreatedOn]		DATETIME NOT NULL, 
    [Timestamp]		DATETIME NOT NULL,
	[CreatedBy]		nvarchar (128) not null,
	[UpdatedBy]		nvarchar (128) null,
	[Deleted]		BIT NOT NULL,
	[DeletedBy]		nvarchar (128) null,
	[DeletedOn]		DATETIME NULL,
	

	 CONSTRAINT [PK_WebQuery] PRIMARY KEY CLUSTERED ([WebQueryId] ASC),
	CONSTRAINT [FK_dbo_WebQuery_UpdatedBy] FOREIGN KEY ([UpdatedBy]) REFERENCES [dbo].[AspNetUsers](Id),
	CONSTRAINT [FK_dbo_WebQuery_DeletedBy] FOREIGN KEY ([DeletedBy]) REFERENCES [dbo].[AspNetUsers](Id),
	
	
)
GO
ALTER TABLE [dbo].[WebQuery] ADD  CONSTRAINT [DF_dbo_WebQuery_Deleted]  DEFAULT ((0)) FOR [Deleted]
GO

