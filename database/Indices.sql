--------------- INDICES ---------------

/* 
As tabelas escolhidas para receberem os indices clusterizados foram as
Localization e Theaters, pois, na teoria, n�o seriam modificadas
com frequ�ncia, visto que, n�o se criam Cinemas todos os dias.
Elas s�o principalmete, tabelas de consulta e pesquisa.
*/

CREATE CLUSTERED INDEX IX_Localization_Address
ON Localization ("Address");
GO

CREATE CLUSTERED INDEX IX_Theaters_Description
ON Theaters ("Description");
GO

/* 
A tabela escolhida para receber o indice n�o clusterizado foi a
Employer, com o intuito de tornar a verifica��o do email de cadastro
para um novo funcion�rio j� existe ou n�o.
*/

CREATE NONCLUSTERED INDEX IX_Employer_Email
ON Employer (Email);
GO