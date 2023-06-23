#nullable enable
using System;
using CoreBluetooth;
using CoreFoundation;
using Foundation;
using ObjCRuntime;
//using iOSDFULibrary;

namespace Laerdal.Dfu.Bindings.iOS
{
	// [Static]
	// partial interface Constants
	// {
	// 	// extern double iOSDFULibraryVersionNumber;
	// 	[Field ("iOSDFULibraryVersionNumber", "__Internal")]
	// 	double iOSDFULibraryVersionNumber { get; }
	//
	// 	// extern const unsigned char[] iOSDFULibraryVersionString;
	// 	[Field ("iOSDFULibraryVersionString", "__Internal")]
	// 	byte[] iOSDFULibraryVersionString { get; }
	// }

	// @interface DFUFirmware : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC13iOSDFULibrary11DFUFirmware")]
	[DisableDefaultCtor]
	[Protocol(Name = "_TtC13iOSDFULibrary11DFUFirmware")]
	interface DFUFirmware
	{
		// @property (readonly, copy, nonatomic) NSString * _Nullable fileName;
		[NullAllowed, Export ("fileName")]
		string FileName { get; }

		// @property (readonly, copy, nonatomic) NSURL * _Nullable fileUrl;
		[NullAllowed, Export ("fileUrl", ArgumentSemantic.Copy)]
		NSUrl FileUrl { get; }

		// @property (readonly, nonatomic) BOOL valid;
		[Export ("valid")]
		bool Valid { get; }

		// @property (readonly, nonatomic, strong) DFUFirmwareSize * _Nonnull size;
		[Export ("size", ArgumentSemantic.Strong)]
		DFUFirmwareSize Size { get; }

		// @property (readonly, nonatomic) NSInteger parts;
		[Export ("parts")]
		nint Parts { get; }

		// -(instancetype _Nullable)initWithUrlToZipFile:(NSURL * _Nonnull)urlToZipFile error:(NSError * _Nullable * _Nullable)error;
		[Export ("initWithUrlToZipFile:error:")]
		IntPtr Constructor (NSUrl urlToZipFile, [NullAllowed] out NSError error);

		// -(instancetype _Nullable)initWithUrlToZipFile:(NSURL * _Nonnull)urlToZipFile type:(enum DFUFirmwareType)type error:(NSError * _Nullable * _Nullable)error __attribute__((objc_designated_initializer));
		[Export ("initWithUrlToZipFile:type:error:")]
		[DesignatedInitializer]
		IntPtr Constructor (NSUrl urlToZipFile, DFUFirmwareType type, [NullAllowed] out NSError error);

		// -(instancetype _Nullable)initWithZipFile:(NSData * _Nonnull)zipFile error:(NSError * _Nullable * _Nullable)error;
		[Export ("initWithZipFile:error:")]
		IntPtr Constructor (NSData zipFile, [NullAllowed] out NSError error);

		// -(instancetype _Nullable)initWithZipFile:(NSData * _Nonnull)zipFile type:(enum DFUFirmwareType)type error:(NSError * _Nullable * _Nullable)error __attribute__((objc_designated_initializer));
		[Export ("initWithZipFile:type:error:")]
		[DesignatedInitializer]
		IntPtr Constructor (NSData zipFile, DFUFirmwareType type, [NullAllowed] out NSError error);

		// -(instancetype _Nullable)initWithUrlToBinOrHexFile:(NSURL * _Nonnull)urlToBinOrHexFile urlToDatFile:(NSURL * _Nullable)urlToDatFile type:(enum DFUFirmwareType)type error:(NSError * _Nullable * _Nullable)error __attribute__((objc_designated_initializer));
		[Export ("initWithUrlToBinOrHexFile:urlToDatFile:type:error:")]
		[DesignatedInitializer]
		IntPtr Constructor (NSUrl urlToBinOrHexFile, [NullAllowed] NSUrl urlToDatFile, DFUFirmwareType type, [NullAllowed] out NSError error);

		// -(instancetype _Nonnull)initWithBinFile:(NSData * _Nonnull)binFile datFile:(NSData * _Nullable)datFile type:(enum DFUFirmwareType)type __attribute__((objc_designated_initializer));
		[Export ("initWithBinFile:datFile:type:")]
		[DesignatedInitializer]
		IntPtr Constructor (NSData binFile, [NullAllowed] NSData datFile, DFUFirmwareType type);

		// -(instancetype _Nullable)initWithHexFile:(NSData * _Nonnull)hexFile datFile:(NSData * _Nullable)datFile type:(enum DFUFirmwareType)type error:(NSError * _Nullable * _Nullable)error __attribute__((objc_designated_initializer));
		[Export ("initWithHexFile:datFile:type:error:")]
		[DesignatedInitializer]
		IntPtr Constructor (NSData hexFile, [NullAllowed] NSData datFile, DFUFirmwareType type, [NullAllowed] out NSError error);
	}

	// @interface DFUFirmwareSize : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC13iOSDFULibrary15DFUFirmwareSize")]
	[DisableDefaultCtor]
	[Protocol(Name = "_TtC13iOSDFULibrary15DFUFirmwareSize")]
	interface DFUFirmwareSize
	{
		// @property (readonly, nonatomic) uint32_t softdevice;
		[Export ("softdevice")]
		uint Softdevice { get; }

		// @property (readonly, nonatomic) uint32_t bootloader;
		[Export ("bootloader")]
		uint Bootloader { get; }

		// @property (readonly, nonatomic) uint32_t application;
		[Export ("application")]
		uint Application { get; }
	}

	// @protocol DFUPeripheralSelectorDelegate
	[Protocol (Name = "_TtP13iOSDFULibrary29DFUPeripheralSelectorDelegate_"), Model]
	[BaseType (typeof(NSObject), Name = "_TtP13iOSDFULibrary29DFUPeripheralSelectorDelegate_")]
	interface DFUPeripheralSelectorDelegate
	{
		// @required -(BOOL)select:(CBPeripheral * _Nonnull)peripheral advertisementData:(NSDictionary<NSString *,id> * _Nonnull)advertisementData RSSI:(NSNumber * _Nonnull)RSSI hint:(NSString * _Nullable)name __attribute__((warn_unused_result("")));
		[Abstract]
		[Export ("select:advertisementData:RSSI:hint:")]
		bool Select (CBPeripheral peripheral, NSDictionary<NSString, NSObject> advertisementData, NSNumber RSSI, [NullAllowed] string name);

		// @required -(NSArray<CBUUID *> * _Nullable)filterByHint:(CBUUID * _Nonnull)dfuServiceUUID __attribute__((warn_unused_result("")));
		[Abstract]
		[Export ("filterByHint:")]
		[return: NullAllowed]
		CBUUID[] FilterByHint (CBUUID dfuServiceUUID);
	}

	// @interface DFUPeripheralSelector : NSObject <DFUPeripheralSelectorDelegate>
	[BaseType (typeof(NSObject), Name = "_TtC13iOSDFULibrary21DFUPeripheralSelector")]
	[Protocol(Name = "_TtC13iOSDFULibrary21DFUPeripheralSelector")]
	interface DFUPeripheralSelector
	{
		// -(BOOL)select:(CBPeripheral * _Nonnull)peripheral advertisementData:(NSDictionary<NSString *,id> * _Nonnull)advertisementData RSSI:(NSNumber * _Nonnull)RSSI hint:(NSString * _Nullable)name __attribute__((warn_unused_result("")));
		[Export ("select:advertisementData:RSSI:hint:")]
		bool Select (CBPeripheral peripheral, NSDictionary<NSString, NSObject> advertisementData, NSNumber RSSI, [NullAllowed] string name);

		// -(NSArray<CBUUID *> * _Nullable)filterByHint:(CBUUID * _Nonnull)dfuServiceUUID __attribute__((warn_unused_result("")));
		[Export ("filterByHint:")]
		[return: NullAllowed]
		CBUUID[] FilterByHint (CBUUID dfuServiceUUID);
	}

	// @protocol DFUProgressDelegate
	[Protocol (Name = "_TtP13iOSDFULibrary19DFUProgressDelegate_"), Model]
	[BaseType (typeof(NSObject), Name = "_TtP13iOSDFULibrary19DFUProgressDelegate_")]
	interface DFUProgressDelegate
	{
		// @required -(void)dfuProgressDidChangeFor:(NSInteger)part outOf:(NSInteger)totalParts to:(NSInteger)progress currentSpeedBytesPerSecond:(double)currentSpeedBytesPerSecond avgSpeedBytesPerSecond:(double)avgSpeedBytesPerSecond;
		[Abstract]
		[Export ("dfuProgressDidChangeFor:outOf:to:currentSpeedBytesPerSecond:avgSpeedBytesPerSecond:")]
		void OutOf (nint part, nint totalParts, nint progress, double currentSpeedBytesPerSecond, double avgSpeedBytesPerSecond);
	}

	// @interface DFUServiceController : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC13iOSDFULibrary20DFUServiceController")]
	[DisableDefaultCtor]
	[Protocol(Name = "_TtC13iOSDFULibrary20DFUServiceController")]
	interface DFUServiceController
	{
		// -(void)pause;
		[Export ("pause")]
		void Pause ();

		// -(void)resume;
		[Export ("resume")]
		void Resume ();

		// -(BOOL)abort __attribute__((warn_unused_result("")));
		[Export ("abort")]
		bool Abort ();

		// -(void)restart;
		[Export ("restart")]
		void Restart ();

		// @property (readonly, nonatomic) BOOL paused;
		[Export ("paused")]
		bool Paused { get; }

		// @property (readonly, nonatomic) BOOL aborted;
		[Export ("aborted")]
		bool Aborted { get; }
	}

	// @protocol DFUServiceDelegate
	[Protocol (Name = "_TtP13iOSDFULibrary18DFUServiceDelegate_"), Model]
	[BaseType (typeof(NSObject), Name = "_TtP13iOSDFULibrary18DFUServiceDelegate_")]
	interface DFUServiceDelegate
	{
		// @required -(void)dfuStateDidChangeTo:(enum DFUState)state;
		[Abstract]
		[Export ("dfuStateDidChangeTo:")]
		void DfuStateDidChangeTo (DFUState state);

		// @required -(void)dfuError:(enum DFUError)error didOccurWithMessage:(NSString * _Nonnull)message;
		[Abstract]
		[Export ("dfuError:didOccurWithMessage:")]
		void DfuError (DFUError error, string message);
	}

	// @interface DFUServiceInitiator : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC13iOSDFULibrary19DFUServiceInitiator")]
	[DisableDefaultCtor]
	[Protocol(Name = "_TtC13iOSDFULibrary19DFUServiceInitiator")]
	interface DFUServiceInitiator
	{
		[Wrap ("WeakDelegate")]
		[NullAllowed]
		DFUServiceDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<DFUServiceDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		[Wrap ("WeakProgressDelegate")]
		[NullAllowed]
		DFUProgressDelegate ProgressDelegate { get; set; }

		// @property (nonatomic, weak) id<DFUProgressDelegate> _Nullable progressDelegate;
		[NullAllowed, Export ("progressDelegate", ArgumentSemantic.Weak)]
		NSObject WeakProgressDelegate { get; set; }

		// @property (nonatomic, weak) id<LoggerDelegate> _Nullable logger;
		[NullAllowed, Export ("logger", ArgumentSemantic.Weak)]
		LoggerDelegate Logger { get; set; }

		// @property (nonatomic, strong) id<DFUPeripheralSelectorDelegate> _Nonnull peripheralSelector;
		[Export ("peripheralSelector", ArgumentSemantic.Strong)]
		DFUPeripheralSelectorDelegate PeripheralSelector { get; set; }

		// @property (nonatomic) uint16_t packetReceiptNotificationParameter;
		[Export ("packetReceiptNotificationParameter")]
		ushort PacketReceiptNotificationParameter { get; set; }

		// @property (nonatomic) BOOL forceDfu;
		[Export ("forceDfu")]
		bool ForceDfu { get; set; }

		// @property (nonatomic) BOOL forceScanningForNewAddressInLegacyDfu;
		[Export ("forceScanningForNewAddressInLegacyDfu")]
		bool ForceScanningForNewAddressInLegacyDfu { get; set; }

		// @property (nonatomic) NSTimeInterval connectionTimeout;
		[Export ("connectionTimeout")]
		double ConnectionTimeout { get; set; }

		// @property (nonatomic) NSTimeInterval dataObjectPreparationDelay;
		[Export ("dataObjectPreparationDelay")]
		double DataObjectPreparationDelay { get; set; }

		// @property (nonatomic) BOOL alternativeAdvertisingNameEnabled;
		[Export ("alternativeAdvertisingNameEnabled")]
		bool AlternativeAdvertisingNameEnabled { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable alternativeAdvertisingName;
		[NullAllowed, Export ("alternativeAdvertisingName")]
		string AlternativeAdvertisingName { get; set; }

		// @property (nonatomic) BOOL enableUnsafeExperimentalButtonlessServiceInSecureDfu;
		[Export ("enableUnsafeExperimentalButtonlessServiceInSecureDfu")]
		bool EnableUnsafeExperimentalButtonlessServiceInSecureDfu { get; set; }

		// @property (nonatomic, strong) DFUUuidHelper * _Nonnull uuidHelper;
		[Export ("uuidHelper", ArgumentSemantic.Strong)]
		DFUUuidHelper UuidHelper { get; set; }

		// @property (nonatomic) BOOL disableResume;
		[Export ("disableResume")]
		bool DisableResume { get; set; }

		// -(instancetype _Nonnull)initWithCentralManager:(CBCentralManager * _Nonnull)centralManager target:(CBPeripheral * _Nonnull)target __attribute__((objc_designated_initializer)) __attribute__((deprecated("Use init(queue: DispatchQueue?) instead.")));
		[Export ("initWithCentralManager:target:")]
		[DesignatedInitializer]
		IntPtr Constructor (CBCentralManager centralManager, CBPeripheral target);

		// -(instancetype _Nonnull)initWithQueue:(dispatch_queue_t _Nullable)queue delegateQueue:(dispatch_queue_t _Nonnull)delegateQueue progressQueue:(dispatch_queue_t _Nonnull)progressQueue loggerQueue:(dispatch_queue_t _Nonnull)loggerQueue centralManagerOptions:(NSDictionary<NSString *,id> * _Nullable)centralManagerOptions __attribute__((objc_designated_initializer));
		[Export ("initWithQueue:delegateQueue:progressQueue:loggerQueue:centralManagerOptions:")]
		[DesignatedInitializer]
		IntPtr Constructor ([NullAllowed] DispatchQueue queue, DispatchQueue delegateQueue, DispatchQueue progressQueue, DispatchQueue loggerQueue, [NullAllowed] NSDictionary<NSString, NSObject> centralManagerOptions);

		// -(DFUServiceInitiator * _Nonnull)withFirmware:(DFUFirmware * _Nonnull)file __attribute__((warn_unused_result("")));
		[Export ("withFirmware:")]
		DFUServiceInitiator WithFirmware (DFUFirmware file);

		// -(DFUServiceController * _Nullable)start __attribute__((warn_unused_result(""))) __attribute__((deprecated("Use start(target: CBPeripheral) instead.")));
		[Export ("start")]
		[return: NullAllowed]
		DFUServiceController Start ();

		// -(DFUServiceController * _Nullable)startWithTarget:(CBPeripheral * _Nonnull)target __attribute__((warn_unused_result("")));
		[Export ("startWithTarget:")]
		[return: NullAllowed]
		DFUServiceController StartWithTarget (CBPeripheral target);

		// -(DFUServiceController * _Nullable)startWithTargetWithIdentifier:(NSUUID * _Nonnull)uuid __attribute__((warn_unused_result("")));
		[Export ("startWithTargetWithIdentifier:")]
		[return: NullAllowed]
		DFUServiceController StartWithTargetWithIdentifier (NSUuid uuid);
	}

	// @interface DFUUuid : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC13iOSDFULibrary7DFUUuid")]
	[DisableDefaultCtor]
	[Protocol(Name = "_TtC13iOSDFULibrary7DFUUuid")]
	interface DFUUuid
	{
		// @property (readonly, nonatomic, strong) CBUUID * _Nonnull uuid;
		[Export ("uuid", ArgumentSemantic.Strong)]
		CBUUID Uuid { get; }

		// @property (readonly, nonatomic) enum DFUUuidType type;
		[Export ("type")]
		DFUUuidType Type { get; }

		// -(instancetype _Nonnull)initWithUUID:(CBUUID * _Nonnull)withUUID forType:(enum DFUUuidType)forType __attribute__((objc_designated_initializer));
		[Export ("initWithUUID:forType:")]
		[DesignatedInitializer]
		IntPtr Constructor (CBUUID withUUID, DFUUuidType forType);
	}

	// @interface DFUUuidHelper : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC13iOSDFULibrary13DFUUuidHelper")]
	[Protocol(Name = "_TtC13iOSDFULibrary13DFUUuidHelper")]
	interface DFUUuidHelper
	{
		// @property (readonly, nonatomic, strong) CBUUID * _Nonnull legacyDFUService;
		[Export ("legacyDFUService", ArgumentSemantic.Strong)]
		CBUUID LegacyDFUService { get; }

		// @property (readonly, nonatomic, strong) CBUUID * _Nonnull legacyDFUControlPoint;
		[Export ("legacyDFUControlPoint", ArgumentSemantic.Strong)]
		CBUUID LegacyDFUControlPoint { get; }

		// @property (readonly, nonatomic, strong) CBUUID * _Nonnull legacyDFUPacket;
		[Export ("legacyDFUPacket", ArgumentSemantic.Strong)]
		CBUUID LegacyDFUPacket { get; }

		// @property (readonly, nonatomic, strong) CBUUID * _Nonnull legacyDFUVersion;
		[Export ("legacyDFUVersion", ArgumentSemantic.Strong)]
		CBUUID LegacyDFUVersion { get; }

		// @property (readonly, nonatomic, strong) CBUUID * _Nonnull secureDFUService;
		[Export ("secureDFUService", ArgumentSemantic.Strong)]
		CBUUID SecureDFUService { get; }

		// @property (readonly, nonatomic, strong) CBUUID * _Nonnull secureDFUControlPoint;
		[Export ("secureDFUControlPoint", ArgumentSemantic.Strong)]
		CBUUID SecureDFUControlPoint { get; }

		// @property (readonly, nonatomic, strong) CBUUID * _Nonnull secureDFUPacket;
		[Export ("secureDFUPacket", ArgumentSemantic.Strong)]
		CBUUID SecureDFUPacket { get; }

		// @property (readonly, nonatomic, strong) CBUUID * _Nonnull buttonlessExperimentalService;
		[Export ("buttonlessExperimentalService", ArgumentSemantic.Strong)]
		CBUUID ButtonlessExperimentalService { get; }

		// @property (readonly, nonatomic, strong) CBUUID * _Nonnull buttonlessExperimentalCharacteristic;
		[Export ("buttonlessExperimentalCharacteristic", ArgumentSemantic.Strong)]
		CBUUID ButtonlessExperimentalCharacteristic { get; }

		// @property (readonly, nonatomic, strong) CBUUID * _Nonnull buttonlessWithoutBonds;
		[Export ("buttonlessWithoutBonds", ArgumentSemantic.Strong)]
		CBUUID ButtonlessWithoutBonds { get; }

		// @property (readonly, nonatomic, strong) CBUUID * _Nonnull buttonlessWithBonds;
		[Export ("buttonlessWithBonds", ArgumentSemantic.Strong)]
		CBUUID ButtonlessWithBonds { get; }

		// -(instancetype _Nonnull)initWithCustomUuids:(NSArray<DFUUuid *> * _Nonnull)uuids;
		[Export ("initWithCustomUuids:")]
		IntPtr Constructor (DFUUuid[] uuids);
	}

	// @interface IntelHex2BinConverter : NSObject
	[BaseType (typeof(NSObject), Name = "_TtC13iOSDFULibrary21IntelHex2BinConverter")]
	[Protocol(Name = "_TtC13iOSDFULibrary21IntelHex2BinConverter")]
	interface IntelHex2BinConverter
	{
	}

	// @interface LegacyDFUServiceInitiator : DFUServiceInitiator
	[BaseType (typeof(DFUServiceInitiator), Name = "_TtC13iOSDFULibrary25LegacyDFUServiceInitiator")]
	[Protocol(Name = "_TtC13iOSDFULibrary25LegacyDFUServiceInitiator")]
	interface LegacyDFUServiceInitiator
	{
		// -(DFUServiceController * _Nullable)startWithTargetWithIdentifier:(NSUUID * _Nonnull)uuid __attribute__((warn_unused_result("")));
		[Export ("startWithTargetWithIdentifier:")]
		[return: NullAllowed]
		DFUServiceController StartWithTargetWithIdentifier (NSUuid uuid);

		// -(instancetype _Nonnull)initWithCentralManager:(CBCentralManager * _Nonnull)centralManager target:(CBPeripheral * _Nonnull)target __attribute__((objc_designated_initializer)) __attribute__((deprecated("")));
		[Export ("initWithCentralManager:target:")]
		[DesignatedInitializer]
		IntPtr Constructor (CBCentralManager centralManager, CBPeripheral target);

		// -(instancetype _Nonnull)initWithQueue:(dispatch_queue_t _Nullable)queue delegateQueue:(dispatch_queue_t _Nonnull)delegateQueue progressQueue:(dispatch_queue_t _Nonnull)progressQueue loggerQueue:(dispatch_queue_t _Nonnull)loggerQueue centralManagerOptions:(NSDictionary<NSString *,id> * _Nullable)centralManagerOptions __attribute__((objc_designated_initializer));
		[Export ("initWithQueue:delegateQueue:progressQueue:loggerQueue:centralManagerOptions:")]
		[DesignatedInitializer]
		IntPtr Constructor ([NullAllowed] DispatchQueue queue, DispatchQueue delegateQueue, DispatchQueue progressQueue, DispatchQueue loggerQueue, [NullAllowed] NSDictionary<NSString, NSObject> centralManagerOptions);
	}

	// @protocol LoggerDelegate
	[Protocol (Name = "_TtP13iOSDFULibrary14LoggerDelegate_"), Model]
	[BaseType (typeof(NSObject), Name = "_TtP13iOSDFULibrary14LoggerDelegate_")]
	interface LoggerDelegate
	{
		// @required -(void)logWith:(enum LogLevel)level message:(NSString * _Nonnull)message;
		[Abstract]
		[Export ("logWith:message:")]
		void Message (LogLevel level, string message);
	}

	// @interface SecureDFUServiceInitiator : DFUServiceInitiator
	[BaseType (typeof(DFUServiceInitiator), Name = "_TtC13iOSDFULibrary25SecureDFUServiceInitiator")]
	[Protocol(Name = "_TtC13iOSDFULibrary25SecureDFUServiceInitiator")]
	interface SecureDFUServiceInitiator
	{
		// -(DFUServiceController * _Nullable)startWithTargetWithIdentifier:(NSUUID * _Nonnull)uuid __attribute__((warn_unused_result("")));
		[Export ("startWithTargetWithIdentifier:")]
		[return: NullAllowed]
		DFUServiceController StartWithTargetWithIdentifier (NSUuid uuid);

		// -(instancetype _Nonnull)initWithCentralManager:(CBCentralManager * _Nonnull)centralManager target:(CBPeripheral * _Nonnull)target __attribute__((objc_designated_initializer)) __attribute__((deprecated("")));
		[Export ("initWithCentralManager:target:")]
		[DesignatedInitializer]
		IntPtr Constructor (CBCentralManager centralManager, CBPeripheral target);

		// -(instancetype _Nonnull)initWithQueue:(dispatch_queue_t _Nullable)queue delegateQueue:(dispatch_queue_t _Nonnull)delegateQueue progressQueue:(dispatch_queue_t _Nonnull)progressQueue loggerQueue:(dispatch_queue_t _Nonnull)loggerQueue centralManagerOptions:(NSDictionary<NSString *,id> * _Nullable)centralManagerOptions __attribute__((objc_designated_initializer));
		[Export ("initWithQueue:delegateQueue:progressQueue:loggerQueue:centralManagerOptions:")]
		[DesignatedInitializer]
		IntPtr Constructor ([NullAllowed] DispatchQueue queue, DispatchQueue delegateQueue, DispatchQueue progressQueue, DispatchQueue loggerQueue, [NullAllowed] NSDictionary<NSString, NSObject> centralManagerOptions);
	}
}

    // The first step to creating a binding is to add your native framework ("MyLibrary.xcframework")
    // to the project.
    // Open your binding csproj and add a section like this
    // <ItemGroup>
    //   <NativeReference Include="MyLibrary.xcframework">
    //     <Kind>Framework</Kind>
    //     <Frameworks></Frameworks>
    //   </NativeReference>
    // </ItemGroup>
    //
    // Once you've added it, you will need to customize it for your specific library:
    //  - Change the Include to the correct path/name of your library
    //  - Change Kind to Static (.a) or Framework (.framework/.xcframework) based upon the library kind and extension.
    //    - Dynamic (.dylib) is a third option but rarely if ever valid, and only on macOS and Mac Catalyst
    //  - If your library depends on other frameworks, add them inside <Frameworks></Frameworks>
    // Example:
    // <NativeReference Include="libs\MyTestFramework.xcframework">
    //   <Kind>Framework</Kind>
    //   <Frameworks>CoreLocation ModelIO</Frameworks>
    // </NativeReference>
    // 
    // Once you've done that, you're ready to move on to binding the API...
    //
    // Here is where you'd define your API definition for the native Objective-C library.
    //
    // For example, to bind the following Objective-C class:
    //
    //     @interface Widget : NSObject {
    //     }
    //
    // The C# binding would look like this:
    //
    //     [BaseType (typeof (NSObject))]
    //     interface Widget {
    //     }
    //
    // To bind Objective-C properties, such as:
    //
    //     @property (nonatomic, readwrite, assign) CGPoint center;
    //
    // You would add a property definition in the C# interface like so:
    //
    //     [Export ("center")]
    //     CGPoint Center { get; set; }
    //
    // To bind an Objective-C method, such as:
    //
    //     -(void) doSomething:(NSObject *)object atIndex:(NSInteger)index;
    //
    // You would add a method definition to the C# interface like so:
    //
    //     [Export ("doSomething:atIndex:")]
    //     void DoSomething (NSObject object, nint index);
    //
    // Objective-C "constructors" such as:
    //
    //     -(id)initWithElmo:(ElmoMuppet *)elmo;
    //
    // Can be bound as:
    //
    //     [Export ("initWithElmo:")]
    //     NativeHandle Constructor (ElmoMuppet elmo);
    //
    // For more information, see https://aka.ms/ios-binding
    //