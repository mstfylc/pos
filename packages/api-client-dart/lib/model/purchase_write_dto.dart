//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_collection/built_collection.dart';
import 'package:mansis_pos_api_client/model/purchase_line_write_dto.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'purchase_write_dto.g.dart';

abstract class PurchaseWriteDto implements Built<PurchaseWriteDto, PurchaseWriteDtoBuilder> {

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'userId')
    String get userId;

    @nullable
    @BuiltValueField(wireName: r'purchaseTime')
    DateTime get purchaseTime;

    @nullable
    @BuiltValueField(wireName: r'invoice')
    String get invoice;

    @BuiltValueField(wireName: r'paymentCompleted')
    bool get paymentCompleted;

    @BuiltValueField(wireName: r'received')
    bool get received;

    @nullable
    @BuiltValueField(wireName: r'payerId')
    String get payerId;

    @nullable
    @BuiltValueField(wireName: r'receiverId')
    String get receiverId;

    @BuiltValueField(wireName: r'supplierId')
    String get supplierId;

    @BuiltValueField(wireName: r'storeId')
    String get storeId;

    @BuiltValueField(wireName: r'lines')
    BuiltList<PurchaseLineWriteDto> get lines;

    PurchaseWriteDto._();

    static void _initializeBuilder(PurchaseWriteDtoBuilder b) => b;

    factory PurchaseWriteDto([void updates(PurchaseWriteDtoBuilder b)]) = _$PurchaseWriteDto;

    @BuiltValueSerializer(custom: true)
    static Serializer<PurchaseWriteDto> get serializer => _$PurchaseWriteDtoSerializer();
}

class _$PurchaseWriteDtoSerializer implements StructuredSerializer<PurchaseWriteDto> {

    @override
    final Iterable<Type> types = const [PurchaseWriteDto, _$PurchaseWriteDto];
    @override
    final String wireName = r'PurchaseWriteDto';

    @override
    Iterable<Object> serialize(Serializers serializers, PurchaseWriteDto object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'companyId')
            ..add(serializers.serialize(object.companyId,
                specifiedType: const FullType(String)));
        result
            ..add(r'userId')
            ..add(serializers.serialize(object.userId,
                specifiedType: const FullType(String)));
        result
            ..add(r'purchaseTime')
            ..add(object.purchaseTime == null ? null : serializers.serialize(object.purchaseTime,
                specifiedType: const FullType(DateTime)));
        result
            ..add(r'invoice')
            ..add(object.invoice == null ? null : serializers.serialize(object.invoice,
                specifiedType: const FullType(String)));
        result
            ..add(r'paymentCompleted')
            ..add(serializers.serialize(object.paymentCompleted,
                specifiedType: const FullType(bool)));
        result
            ..add(r'received')
            ..add(serializers.serialize(object.received,
                specifiedType: const FullType(bool)));
        result
            ..add(r'payerId')
            ..add(object.payerId == null ? null : serializers.serialize(object.payerId,
                specifiedType: const FullType(String)));
        result
            ..add(r'receiverId')
            ..add(object.receiverId == null ? null : serializers.serialize(object.receiverId,
                specifiedType: const FullType(String)));
        result
            ..add(r'supplierId')
            ..add(serializers.serialize(object.supplierId,
                specifiedType: const FullType(String)));
        result
            ..add(r'storeId')
            ..add(serializers.serialize(object.storeId,
                specifiedType: const FullType(String)));
        result
            ..add(r'lines')
            ..add(serializers.serialize(object.lines,
                specifiedType: const FullType(BuiltList, [FullType(PurchaseLineWriteDto)])));
        return result;
    }

    @override
    PurchaseWriteDto deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = PurchaseWriteDtoBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'companyId':
                    result.companyId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'userId':
                    result.userId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'purchaseTime':
                    result.purchaseTime = serializers.deserialize(value,
                        specifiedType: const FullType(DateTime)) as DateTime;
                    break;
                case r'invoice':
                    result.invoice = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'paymentCompleted':
                    result.paymentCompleted = serializers.deserialize(value,
                        specifiedType: const FullType(bool)) as bool;
                    break;
                case r'received':
                    result.received = serializers.deserialize(value,
                        specifiedType: const FullType(bool)) as bool;
                    break;
                case r'payerId':
                    result.payerId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'receiverId':
                    result.receiverId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'supplierId':
                    result.supplierId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'storeId':
                    result.storeId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'lines':
                    result.lines.replace(serializers.deserialize(value,
                        specifiedType: const FullType(BuiltList, [FullType(PurchaseLineWriteDto)])) as BuiltList<PurchaseLineWriteDto>);
                    break;
            }
        }
        return result.build();
    }
}

