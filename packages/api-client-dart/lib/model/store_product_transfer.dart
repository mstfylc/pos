//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_collection/built_collection.dart';
import 'package:mansis_pos_api_client/model/product_transfer_state.dart';
import 'package:mansis_pos_api_client/model/store_product_transfer_line.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'store_product_transfer.g.dart';

abstract class StoreProductTransfer implements Built<StoreProductTransfer, StoreProductTransferBuilder> {

    @BuiltValueField(wireName: r'id')
    String get id;

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'sourceStoreId')
    String get sourceStoreId;

    @BuiltValueField(wireName: r'targetStoreId')
    String get targetStoreId;

    @BuiltValueField(wireName: r'requestedById')
    String get requestedById;

    @BuiltValueField(wireName: r'requestedTime')
    DateTime get requestedTime;

    @BuiltValueField(wireName: r'transferState')
    ProductTransferState get transferState;
    // enum transferStateEnum {  Requested,  Confirmed,  Received,  Cancelled,  };

    @nullable
    @BuiltValueField(wireName: r'confirmedById')
    String get confirmedById;

    @nullable
    @BuiltValueField(wireName: r'confirmedTime')
    DateTime get confirmedTime;

    @nullable
    @BuiltValueField(wireName: r'receivedById')
    String get receivedById;

    @nullable
    @BuiltValueField(wireName: r'receivedTime')
    DateTime get receivedTime;

    @nullable
    @BuiltValueField(wireName: r'cancelledById')
    String get cancelledById;

    @nullable
    @BuiltValueField(wireName: r'cancelledTime')
    DateTime get cancelledTime;

    @nullable
    @BuiltValueField(wireName: r'cancelReason')
    String get cancelReason;

    @nullable
    @BuiltValueField(wireName: r'transferDone')
    bool get transferDone;

    @BuiltValueField(wireName: r'lines')
    BuiltList<StoreProductTransferLine> get lines;

    StoreProductTransfer._();

    static void _initializeBuilder(StoreProductTransferBuilder b) => b;

    factory StoreProductTransfer([void updates(StoreProductTransferBuilder b)]) = _$StoreProductTransfer;

    @BuiltValueSerializer(custom: true)
    static Serializer<StoreProductTransfer> get serializer => _$StoreProductTransferSerializer();
}

class _$StoreProductTransferSerializer implements StructuredSerializer<StoreProductTransfer> {

    @override
    final Iterable<Type> types = const [StoreProductTransfer, _$StoreProductTransfer];
    @override
    final String wireName = r'StoreProductTransfer';

    @override
    Iterable<Object> serialize(Serializers serializers, StoreProductTransfer object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'id')
            ..add(serializers.serialize(object.id,
                specifiedType: const FullType(String)));
        result
            ..add(r'companyId')
            ..add(serializers.serialize(object.companyId,
                specifiedType: const FullType(String)));
        result
            ..add(r'sourceStoreId')
            ..add(serializers.serialize(object.sourceStoreId,
                specifiedType: const FullType(String)));
        result
            ..add(r'targetStoreId')
            ..add(serializers.serialize(object.targetStoreId,
                specifiedType: const FullType(String)));
        result
            ..add(r'requestedById')
            ..add(serializers.serialize(object.requestedById,
                specifiedType: const FullType(String)));
        result
            ..add(r'requestedTime')
            ..add(serializers.serialize(object.requestedTime,
                specifiedType: const FullType(DateTime)));
        result
            ..add(r'transferState')
            ..add(serializers.serialize(object.transferState,
                specifiedType: const FullType(ProductTransferState)));
        if (object.confirmedById != null) {
            result
                ..add(r'confirmedById')
                ..add(serializers.serialize(object.confirmedById,
                    specifiedType: const FullType(String)));
        }
        if (object.confirmedTime != null) {
            result
                ..add(r'confirmedTime')
                ..add(serializers.serialize(object.confirmedTime,
                    specifiedType: const FullType(DateTime)));
        }
        if (object.receivedById != null) {
            result
                ..add(r'receivedById')
                ..add(serializers.serialize(object.receivedById,
                    specifiedType: const FullType(String)));
        }
        if (object.receivedTime != null) {
            result
                ..add(r'receivedTime')
                ..add(serializers.serialize(object.receivedTime,
                    specifiedType: const FullType(DateTime)));
        }
        if (object.cancelledById != null) {
            result
                ..add(r'cancelledById')
                ..add(serializers.serialize(object.cancelledById,
                    specifiedType: const FullType(String)));
        }
        if (object.cancelledTime != null) {
            result
                ..add(r'cancelledTime')
                ..add(serializers.serialize(object.cancelledTime,
                    specifiedType: const FullType(DateTime)));
        }
        if (object.cancelReason != null) {
            result
                ..add(r'cancelReason')
                ..add(serializers.serialize(object.cancelReason,
                    specifiedType: const FullType(String)));
        }
        if (object.transferDone != null) {
            result
                ..add(r'transferDone')
                ..add(serializers.serialize(object.transferDone,
                    specifiedType: const FullType(bool)));
        }
        result
            ..add(r'lines')
            ..add(serializers.serialize(object.lines,
                specifiedType: const FullType(BuiltList, [FullType(StoreProductTransferLine)])));
        return result;
    }

    @override
    StoreProductTransfer deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = StoreProductTransferBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'id':
                    result.id = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'companyId':
                    result.companyId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'sourceStoreId':
                    result.sourceStoreId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'targetStoreId':
                    result.targetStoreId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'requestedById':
                    result.requestedById = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'requestedTime':
                    result.requestedTime = serializers.deserialize(value,
                        specifiedType: const FullType(DateTime)) as DateTime;
                    break;
                case r'transferState':
                    result.transferState = serializers.deserialize(value,
                        specifiedType: const FullType(ProductTransferState)) as ProductTransferState;
                    break;
                case r'confirmedById':
                    result.confirmedById = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'confirmedTime':
                    result.confirmedTime = serializers.deserialize(value,
                        specifiedType: const FullType(DateTime)) as DateTime;
                    break;
                case r'receivedById':
                    result.receivedById = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'receivedTime':
                    result.receivedTime = serializers.deserialize(value,
                        specifiedType: const FullType(DateTime)) as DateTime;
                    break;
                case r'cancelledById':
                    result.cancelledById = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'cancelledTime':
                    result.cancelledTime = serializers.deserialize(value,
                        specifiedType: const FullType(DateTime)) as DateTime;
                    break;
                case r'cancelReason':
                    result.cancelReason = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'transferDone':
                    result.transferDone = serializers.deserialize(value,
                        specifiedType: const FullType(bool)) as bool;
                    break;
                case r'lines':
                    result.lines.replace(serializers.deserialize(value,
                        specifiedType: const FullType(BuiltList, [FullType(StoreProductTransferLine)])) as BuiltList<StoreProductTransferLine>);
                    break;
            }
        }
        return result.build();
    }
}

