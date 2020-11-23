--------------- INDICES ---------------

/* 
As tabelas escolhidas para receberem os indices clusterizados foram as
Localization e Theaters, pois, na teoria, não seriam modificadas
com frequência, visto que, não se criam Cinemas todos os dias.
Elas são principalmete, tabelas de consulta e pesquisa.
*/

CREATE CLUSTERED INDEX IX_Localization_Address
ON Localization ("Address");
GO

CREATE CLUSTERED INDEX IX_Theaters_Description
ON Theaters ("Description");
GO

/* 
A tabela escolhida para receber o indice não clusterizado foi a
Employer, com o intuito de tornar a verificação do email de cadastro
para um novo funcionário já existe ou não.
*/

CREATE NONCLUSTERED INDEX IX_Employer_Email
ON Employer (Email);
GO