using LoanManagement.Core;
using LoanManagement.Core.Logging;
using LoanManagement.Data;
using LoanManagement.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LoanManagement.Tests.LoanManagement.Core.Tests
{
    public class LoanHandlerServiceTests
    {

        /// <summary>
        /// A moq object for the ILog interface.
        /// </summary>
        private Mock<ILog> MoqLogHandler;

        //A moq object for the IInterestrateRetriever object.
        private Mock<IInterestrateRetriever> moqInterestRateRetreiver;
        /// <summary>
        /// A moq object for the customer storage.
        /// </summary>
        private Mock<IStorage<Customer>> moqCustomerStorage;

        /// <summary>
        /// A moq object for the loan storage.
        /// </summary>
        private Mock<IStorage<Loan>> moqLoanStorage;

        /// <summary>
        /// A moq object for the loan product storage.
        /// </summary>
        private Mock<IStorage<LoanProduct>> moqLoanProductStorage;

        /// <summary>
        /// A moq object for the IRepository.
        /// </summary>
        private Mock<IRepository> MoqRepository;

        /// <summary>
        /// The default constructor
        /// </summary>
        public LoanHandlerServiceTests()
        {
            var sampleCustomer = new Customer()
            {
                Id = 1,
                PersonNumber = "19700101-1023"
            };

            var sampleLoanProduct = new LoanProduct()
            {
                Id = 1,
                ProductType = Models.Entities.LoanProductType.Big
            };

            var sampleLoan = new Loan()
            {
                Id = 1,
                ExtraCosts = 0,
                LoanNumber = "XX/1",
                PaymentDate = new DateTime(2017, 01, 01),
                Customer = sampleCustomer,
                LoanProduct = sampleLoanProduct
            };

            //Initializing the ILog moq object.
            MoqLogHandler = new Moq.Mock<ILog>();
            MoqLogHandler.Setup(x => x.Log(It.IsAny<LogLevel>(), It.IsAny<string>())).Verifiable();

            //Initializing the IInterestRateRetreiver object.
            moqInterestRateRetreiver = new Moq.Mock<IInterestrateRetriever>();
            moqInterestRateRetreiver.Setup(x => x.GetCurrentInterestRate()).Returns(() => { return 0.25M; });

            //Initializing the Customer storage moq.
            moqCustomerStorage = new Mock<IStorage<Customer>>();
            moqCustomerStorage.Setup(x => x.Add(ref It.Ref<Customer>.IsAny)).Returns(true);
            moqCustomerStorage.Setup(x => x.Update(It.IsAny<Customer>())).Verifiable();
            moqCustomerStorage.Setup(x => x.Get(It.IsAny<int>())).
                Returns(sampleCustomer);
            moqCustomerStorage.Setup(x => x.FindByCustomReference(It.IsAny<string>())).
                Returns(sampleCustomer);

            ///Initializing the loan storage moq.
            moqLoanStorage = new Mock<IStorage<Loan>>();
            moqLoanStorage.Setup(x => x.Add(ref It.Ref<Loan>.IsAny)).Returns(true);
            moqLoanStorage.Setup(x => x.Update(It.IsAny<Loan>())).Verifiable();
            moqLoanStorage.Setup(x => x.Get(It.IsAny<int>())).
                Returns(sampleLoan);
            moqLoanStorage.Setup(x => x.FindByCustomReference(It.IsAny<string>())).
                Returns(sampleLoan);

            //Initializing the loan product storage moq.
            moqLoanProductStorage = new Mock<IStorage<LoanProduct>>();
            moqLoanProductStorage.Setup(x => x.Add(ref It.Ref<LoanProduct>.IsAny)).Returns(true);
            moqLoanProductStorage.Setup(x => x.Update(It.IsAny<LoanProduct>())).Verifiable();
            moqLoanProductStorage.Setup(x => x.Get(It.IsAny<int>())).
                Returns(sampleLoanProduct);
            moqLoanProductStorage.Setup(x => x.FindByCustomReference(It.IsAny<string>())).
                Returns(sampleLoanProduct);

            //Initializing the IRepository moq.
            MoqRepository = new Mock<IRepository>();
            MoqRepository.Setup(x => x.Customers).Returns(moqCustomerStorage.Object);
            MoqRepository.Setup(x => x.Loans).Returns(moqLoanStorage.Object);
            MoqRepository.Setup(x => x.LoanProducts).Returns(moqLoanProductStorage.Object);

        }
        [Fact]
        [Trait("LoanHandlingService", "RegisterLoan")]
        public void RegisterLoan_Succeeds()
        {
            var loanHandlerService = new LoanHandlingService(MoqRepository.Object, new LoanCalculator())
            {
                InterestrateRetriever = moqInterestRateRetreiver.Object,
                LogHandler = MoqLogHandler.Object
            };

            bool actual = loanHandlerService.RegisterLoan(new LoanRegistrationModel()
            {
                ExtraCosts=0,
                LoanNumber= "XX/1",
                LoanProductId=1,
                PaymentDate=new DateTime(2017,01,01),
                PersonNumber= "19700101-1023"
            });

            Assert.True(actual);
        }

        [Fact]
        [Trait("LoanHandlingService", "RegisterLoan")]
        public void RegisterLoanRepayment_SmallLoan_Succeeds()
        {
            var loanHandlerService = new LoanHandlingService(MoqRepository.Object, new LoanCalculator())
            {
                InterestrateRetriever = moqInterestRateRetreiver.Object,
                LogHandler = MoqLogHandler.Object
            };

            bool actual = loanHandlerService.RegisterLoanRepayment(new LoanRepaymentRegistrationModel()
            {
                LoanNumber = "XX/1",
                PersonNumber = "19700101-1023",
                RepaymentDate = new DateTime(2019, 01, 01)
            });

            Assert.True(actual);


        }
    }
}
