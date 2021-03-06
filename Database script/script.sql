USE [ContactInformation]
GO
/****** Object:  Table [dbo].[tbl_ContactDetails]    Script Date: 08-08-2018 19:40:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_ContactDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](150) NULL,
	[LastName] [nvarchar](150) NULL,
	[Email] [nvarchar](50) NULL,
	[PhoneNumber] [nvarchar](150) NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_tbl_ContactDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  StoredProcedure [dbo].[DeleteContactInformation]    Script Date: 08-08-2018 19:40:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DeleteContactInformation]
	@Id int=0

	AS
	BEGIN

	UPDATE [dbo].[tbl_ContactDetails]  SET [Status]=0 WHERE Id=@Id


	
	END

GO
/****** Object:  StoredProcedure [dbo].[GetContactDetails]    Script Date: 08-08-2018 19:40:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetContactDetails]

AS
BEGIN


SELECT * FROM [dbo].[tbl_ContactDetails]  where status=1
END

GO
/****** Object:  StoredProcedure [dbo].[GetContactInformation]    Script Date: 08-08-2018 19:40:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetContactInformation] 
	@Id int=0

	AS
	BEGIN

	SELECT * FROM [dbo].[tbl_ContactDetails] WHERE Id=@Id
	
	END
GO
/****** Object:  StoredProcedure [dbo].[SaveUserContactDetails]    Script Date: 08-08-2018 19:40:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SaveUserContactDetails]
@FirstName nvarchar(150)=null,
@LastName nvarchar(150)=null,
@Email nvarchar(150)=null,
@PhoneNumber nvarchar(150)=null,
@Status bit=0,
@Id int=0

AS 
BEGIN
DECLARE @Message NVARCHAR(150)
IF NOT EXISTS(SELECT 1 FROM [tbl_ContactDetails] WHERE Id=@Id)
BEGIN
INSERT INTO [dbo].[tbl_ContactDetails]
           ([FirstName]
           ,[LastName]
           ,[Email]
           ,[PhoneNumber]
           ,[Status])
     VALUES
           (@FirstName
           ,@LastName
           ,@Email
           ,@PhoneNumber
           ,@Status)

SET  @Message='Insert Successfully'
END
ELSE
BEGIN


UPDATE [dbo].[tbl_ContactDetails]
   SET [FirstName] = @FirstName
      ,[LastName] = @LastName
      ,[Email] =@Email
      ,[PhoneNumber] = @PhoneNumber
      ,[Status] = @Status
 WHERE Id=@Id
END

END
GO
