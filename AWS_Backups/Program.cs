using System;
using System.Collections.Generic;
using Amazon;
using Amazon.EC2.Model;

// Add using statements to access AWS SDK for .NET services. 
// Both the Service and its Model namespace need to be added 
// in order to gain access to a service. For example, to access
// the EC2 service, add:
// using Amazon.EC2;
// using Amazon.EC2.Model;

namespace AWS_Backups
{
    class Program
    {
        public static void Main(string[] args)
        {
            //IAmazonS3 s3Client = AWSClientFactory.CreateAmazonS3Client();
            var ec2Client = AWSClientFactory.CreateAmazonEC2Client();

            var describeSnapshotsRequest = new DescribeSnapshotsRequest
            {
                OwnerIds = new List<string> {"144324524868"}
            };

            var describeSnapshotsResponse = ec2Client.DescribeSnapshots(describeSnapshotsRequest);

            foreach (var snapshot in describeSnapshotsResponse.Snapshots)
            {
                Console.WriteLine("Description: {0}", snapshot.Description);
            }

            Console.Read();
        }
    }
}