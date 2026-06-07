//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'stock_movement_dto.g.dart';

abstract class StockMovementDto implements Built<StockMovementDto, StockMovementDtoBuilder> {

    @BuiltValueField(wireName: r'id')
    String get id;

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'storeId')
    String get storeId;

    @BuiltValueField(wireName: r'productId')
    String get productId;

    @nullable
    @BuiltValueField(wireName: r'operationId')
    String get operationId;

    @BuiltValueField(wireName: r'movementType')
    int get movementType;

    @BuiltValueField(wireName: r'direction')
    int get direction;

    @BuiltValueField(wireName: r'quantity')
    int get quantity;

    @BuiltValueField(wireName: r'state')
    int get state;

    @nullable
    @BuiltValueField(wireName: r'reversalOfId')
    String get reversalOfId;

    @nullable
    @BuiltValueField(wireName: r'description')
    String get description;

    @BuiltValueField(wireName: r'occurredAt')
    DateTime get occurredAt;

    @BuiltValueField(wireName: r'currentQuantity')
    int get currentQuantity;

    StockMovementDto._();

    static void _initializeBuilder(StockMovementDtoBuilder b) => b;

    factory StockMovementDto([void updates(StockMovementDtoBuilder b)]) = _$StockMovementDto;

    @BuiltValueSerializer(custom: true)
    static Serializer<StockMovementDto> get serializer => _$StockMovementDtoSerializer();
}

class _$StockMovementDtoSerializer implements StructuredSerializer<StockMovementDto> {

    @override
    final Iterable<Type> types = const [StockMovementDto, _$StockMovementDto];
    @override
    final String wireName = r'StockMovementDto';

    @override
    Iterable<Object> serialize(Serializers serializers, StockMovementDto object,
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
            ..add(r'storeId')
            ..add(serializers.serialize(object.storeId,
                specifiedType: const FullType(String)));
        result
            ..add(r'productId')
            ..add(serializers.serialize(object.productId,
                specifiedType: const FullType(String)));
        result
            ..add(r'operationId')
            ..add(object.operationId == null ? null : serializers.serialize(object.operationId,
                specifiedType: const FullType(String)));
        result
            ..add(r'movementType')
            ..add(serializers.serialize(object.movementType,
                specifiedType: const FullType(int)));
        result
            ..add(r'direction')
            ..add(serializers.serialize(object.direction,
                specifiedType: const FullType(int)));
        result
            ..add(r'quantity')
            ..add(serializers.serialize(object.quantity,
                specifiedType: const FullType(int)));
        result
            ..add(r'state')
            ..add(serializers.serialize(object.state,
                specifiedType: const FullType(int)));
        result
            ..add(r'reversalOfId')
            ..add(object.reversalOfId == null ? null : serializers.serialize(object.reversalOfId,
                specifiedType: const FullType(String)));
        result
            ..add(r'description')
            ..add(object.description == null ? null : serializers.serialize(object.description,
                specifiedType: const FullType(String)));
        result
            ..add(r'occurredAt')
            ..add(serializers.serialize(object.occurredAt,
                specifiedType: const FullType(DateTime)));
        result
            ..add(r'currentQuantity')
            ..add(serializers.serialize(object.currentQuantity,
                specifiedType: const FullType(int)));
        return result;
    }

    @override
    StockMovementDto deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = StockMovementDtoBuilder();

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
                case r'storeId':
                    result.storeId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'productId':
                    result.productId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'operationId':
                    result.operationId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'movementType':
                    result.movementType = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'direction':
                    result.direction = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'quantity':
                    result.quantity = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'state':
                    result.state = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'reversalOfId':
                    result.reversalOfId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'description':
                    result.description = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'occurredAt':
                    result.occurredAt = serializers.deserialize(value,
                        specifiedType: const FullType(DateTime)) as DateTime;
                    break;
                case r'currentQuantity':
                    result.currentQuantity = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
            }
        }
        return result.build();
    }
}

