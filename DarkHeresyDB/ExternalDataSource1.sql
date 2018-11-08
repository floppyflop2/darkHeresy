CREATE EXTERNAL DATA SOURCE [ExternalDataSource1] WITH
(  
	TYPE = HADOOP,
	LOCATION = 'hdfs://NameNode_URI[:port]'
)