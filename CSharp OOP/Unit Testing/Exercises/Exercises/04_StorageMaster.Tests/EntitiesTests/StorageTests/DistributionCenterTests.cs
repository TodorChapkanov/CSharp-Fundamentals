using _04_StorageMaster.Entities.Products;
using _04_StorageMaster.Entities.Storage;
using NUnit.Framework;

namespace _04_StorageMaster.Structure.Tests.EntitiesTests.StorageTests
{
   public class DistributionCenterTests
    {
        Storage warehouse;

        [SetUp]
        public void SetUp()
        {
            warehouse = new DistributionCenter("Warehouse");
        }

        [Test]
        public void NameSet()
        {
            Assert.That(warehouse.Name == "Warehouse",
                "Name is not set properly");
        }

        [Test]
        public void CapacitySet()
        {
            var warehouseCapacity = 2;

            Assert.AreEqual(warehouseCapacity, warehouse.Capacity,
                "Capacity are not set properly");
        }

        [Test]
        public void GarageSlotsSet()
        {
            var currentSlotsCount = 5;

            Assert.AreEqual(currentSlotsCount, warehouse.GarageSlots,
                "GaragSlots are not set properly");
        }

        [Test]
        public void IsFullShouldReturnTrueIfIsFull()
        {

            var product = new HardDrive(10);
            var vehicle = warehouse.GetVehicle(0);
            vehicle.LoadProduct(product);
            vehicle.LoadProduct(product);


            warehouse.UnloadVehicle(0);

            Assert.IsTrue(warehouse.IsFull,
                "IsFull is not set properly");
        }

        [Test]
        public void IsFullShouldReturnFalseIfIsEmpty()
        {
            Assert.IsFalse(warehouse.IsFull,
                "IsFull doesn't return false when is empty");
        }

        [Test]
        public void GetVehicleShouldReturnVanWithCorrectIndex()
        {
            var van = warehouse.GetVehicle(0);
            Assert.IsNotNull(van, "GetVehicl doesn't returt correct vehicle");
        }

        [Test]
        public void GetVehicleShouldThrowExceptionIfIndexIsOutOfRange()
        {
            Assert.That(() => warehouse.GetVehicle(5),
                Throws.InvalidOperationException
                .With
                .Message
                .EqualTo("Invalid garage slot!")
                , "GetVehicle trow different exception with different message when vehicle slot is out of range");
        }

        [Test]
        public void GetVehicleShouldThrowExceptionIfNoVehicleOnCorrectSlot()
        {
            Assert.That(() => warehouse.GetVehicle(4),
                Throws.InvalidOperationException
                .With
                .Message
                .EqualTo("No vehicle in this garage slot!")
                , "GetVehicle throw different exception with different message when vehicle slot is empty");
        }

        [Test]
        public void SendVehicleToShouldReturnIndexOfSlot()
        {
            var otherWarehouse = new AutomatedWarehouse("Merkado");

            var expectedValue = 1;
            var actualValue = warehouse.SendVehicleTo(0, otherWarehouse);

            Assert.AreEqual(expectedValue, actualValue, "SendVehicleTo retur different slot number");
        }

        [Test]
        public void SendVehicleToShouldThrowExceptionIfNoFreeSlotsInOtherWarehouse()
        {
            var firstWarehouse = new AutomatedWarehouse("Merkado");
            var secondWarehouse = new AutomatedWarehouse("Merkado1");
            firstWarehouse.SendVehicleTo(0, secondWarehouse);

            Assert.That(() => warehouse.SendVehicleTo(0, secondWarehouse),
                Throws.InvalidOperationException
                .With
                .Message
                .EqualTo("No room in garage!"));
        }

        [Test]
        public void UnloadVehicleShouldReturnUnloadedProductsCount()
        {
            var vehicle = warehouse.GetVehicle(0);
            var product = new SolidStateDrive(58.20);
            for (int i = 0; i < 3; i++)
            {
                vehicle.LoadProduct(product);
            }

            var unloadedProductsCount = warehouse.UnloadVehicle(0);
            var expectedValue = 3;

            Assert.AreEqual(expectedValue, unloadedProductsCount,
                $"UnloadVehicle method return {unloadedProductsCount} when should be {expectedValue} products unloaded");
        }

        [Test]
        public void UnloadVehicleShouldThrowExceptionIfWarehouseIsFull()
        {
            var vehicle = warehouse.GetVehicle(0);
            var product = new HardDrive(185.25);
            for (int i = 0; i < 2; i++)
            {
                vehicle.LoadProduct(product);
                warehouse.UnloadVehicle(0);
            }

            vehicle.LoadProduct(product);

            Assert.That(() => warehouse.UnloadVehicle(0),
                Throws.InvalidOperationException
                .With
                .Message
                .EqualTo("Storage is full!"),
                "UnloadVehicle method throw different exception with different message when warehouse is full");
        }
    }
}
