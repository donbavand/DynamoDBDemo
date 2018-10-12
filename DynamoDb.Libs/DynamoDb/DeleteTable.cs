using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

namespace DynamoDb.Libs.DynamoDb
{
    public class DeleteTable : IDeleteTable
    {
        private readonly IAmazonDynamoDB _dynamoClient;

        public DeleteTable(IAmazonDynamoDB dynamoClient)
        {
            _dynamoClient = dynamoClient;
        }

        public async Task<DeleteTableResponse> ExecuteTableDelete(string tableName)
        {
            var request = new DeleteTableRequest
            {
                TableName = tableName
            };

            var response = await _dynamoClient.DeleteTableAsync(request);

            return response;
        }
    }
}