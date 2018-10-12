using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

namespace DynamoDb.Libs.DynamoDb
{
    public class PutItem : IPutItem
    {
	    private readonly IAmazonDynamoDB _dynamoClient;

	    public PutItem(IAmazonDynamoDB dynamoClient)
	    {
		    _dynamoClient = dynamoClient;
	    }

	    public async Task AddNewEntry(int id, string replyDateTime, double price)
	    {
		    var queryRequest = RequestBuilder(id, replyDateTime, price);

		    await PutItemAsync(queryRequest);
	    }

        private PutItemRequest RequestBuilder(int id, string replyDateTime, double price)
	    {
		    var item = new Dictionary<string, AttributeValue>
		    {
			    {"Id", new AttributeValue {N = id.ToString()}},
			    {"ReplyDateTime", new AttributeValue {N = replyDateTime}},
                {"Price", new AttributeValue {N = price.ToString(CultureInfo.InvariantCulture)}}
            };

		    return new PutItemRequest
		    {
			    TableName = "TempDynamoDbTable",
			    Item = item
		    };
	    }

	    private async Task PutItemAsync(PutItemRequest request)
	    {
		    await _dynamoClient.PutItemAsync(request);
	    }
    }
}
