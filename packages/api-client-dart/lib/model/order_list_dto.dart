//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'order_list_dto.g.dart';

abstract class OrderListDto implements Built<OrderListDto, OrderListDtoBuilder> {

    @BuiltValueField(wireName: r'id')
    String get id;

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'posId')
    String get posId;

    @nullable
    @BuiltValueField(wireName: r'customerId')
    String get customerId;

    @BuiltValueField(wireName: r'orderTime')
    DateTime get orderTime;

    @BuiltValueField(wireName: r'subTotal')
    double get subTotal;

    @BuiltValueField(wireName: r'taxTotal')
    double get taxTotal;

    @nullable
    @BuiltValueField(wireName: r'totalDiscount')
    double get totalDiscount;

    @BuiltValueField(wireName: r'total')
    double get total;

    @BuiltValueField(wireName: r'orderState')
    int get orderState;

    @BuiltValueField(wireName: r'paymentSummary')
    int get paymentSummary;

    @nullable
    @BuiltValueField(wireName: r'description')
    String get description;

    @nullable
    @BuiltValueField(wireName: r'addressId')
    String get addressId;

    OrderListDto._();

    static void _initializeBuilder(OrderListDtoBuilder b) => b;

    factory OrderListDto([void updates(OrderListDtoBuilder b)]) = _$OrderListDto;

    @BuiltValueSerializer(custom: true)
    static Serializer<OrderListDto> get serializer => _$OrderListDtoSerializer();
}

class _$OrderListDtoSerializer implements StructuredSerializer<OrderListDto> {

    @override
    final Iterable<Type> types = const [OrderListDto, _$OrderListDto];
    @override
    final String wireName = r'OrderListDto';

    @override
    Iterable<Object> serialize(Serializers serializers, OrderListDto object,
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
            ..add(r'posId')
            ..add(serializers.serialize(object.posId,
                specifiedType: const FullType(String)));
        result
            ..add(r'customerId')
            ..add(object.customerId == null ? null : serializers.serialize(object.customerId,
                specifiedType: const FullType(String)));
        result
            ..add(r'orderTime')
            ..add(serializers.serialize(object.orderTime,
                specifiedType: const FullType(DateTime)));
        result
            ..add(r'subTotal')
            ..add(serializers.serialize(object.subTotal,
                specifiedType: const FullType(double)));
        result
            ..add(r'taxTotal')
            ..add(serializers.serialize(object.taxTotal,
                specifiedType: const FullType(double)));
        result
            ..add(r'totalDiscount')
            ..add(object.totalDiscount == null ? null : serializers.serialize(object.totalDiscount,
                specifiedType: const FullType(double)));
        result
            ..add(r'total')
            ..add(serializers.serialize(object.total,
                specifiedType: const FullType(double)));
        result
            ..add(r'orderState')
            ..add(serializers.serialize(object.orderState,
                specifiedType: const FullType(int)));
        result
            ..add(r'paymentSummary')
            ..add(serializers.serialize(object.paymentSummary,
                specifiedType: const FullType(int)));
        result
            ..add(r'description')
            ..add(object.description == null ? null : serializers.serialize(object.description,
                specifiedType: const FullType(String)));
        result
            ..add(r'addressId')
            ..add(object.addressId == null ? null : serializers.serialize(object.addressId,
                specifiedType: const FullType(String)));
        return result;
    }

    @override
    OrderListDto deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = OrderListDtoBuilder();

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
                case r'posId':
                    result.posId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'customerId':
                    result.customerId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'orderTime':
                    result.orderTime = serializers.deserialize(value,
                        specifiedType: const FullType(DateTime)) as DateTime;
                    break;
                case r'subTotal':
                    result.subTotal = serializers.deserialize(value,
                        specifiedType: const FullType(double)) as double;
                    break;
                case r'taxTotal':
                    result.taxTotal = serializers.deserialize(value,
                        specifiedType: const FullType(double)) as double;
                    break;
                case r'totalDiscount':
                    result.totalDiscount = serializers.deserialize(value,
                        specifiedType: const FullType(double)) as double;
                    break;
                case r'total':
                    result.total = serializers.deserialize(value,
                        specifiedType: const FullType(double)) as double;
                    break;
                case r'orderState':
                    result.orderState = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'paymentSummary':
                    result.paymentSummary = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'description':
                    result.description = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'addressId':
                    result.addressId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
            }
        }
        return result.build();
    }
}

