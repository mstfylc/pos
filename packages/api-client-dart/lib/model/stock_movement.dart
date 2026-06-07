//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:mansis_pos_api_client/model/ledger_entry_state.dart';
import 'package:mansis_pos_api_client/model/store_product_movement_type.dart';
import 'package:mansis_pos_api_client/model/ledger_direction.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'stock_movement.g.dart';

abstract class StockMovement implements Built<StockMovement, StockMovementBuilder> {

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
    StoreProductMovementType get movementType;
    // enum movementTypeEnum {  StockIn,  StockOut,  Destroy,  Order,  Purchase,  TransferIn,  TransferOut,  };

    @BuiltValueField(wireName: r'direction')
    LedgerDirection get direction;
    // enum directionEnum {  Debit,  Credit,  };

    @BuiltValueField(wireName: r'quantity')
    int get quantity;

    @BuiltValueField(wireName: r'state')
    LedgerEntryState get state;
    // enum stateEnum {  Posted,  Reversed,  };

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

    StockMovement._();

    static void _initializeBuilder(StockMovementBuilder b) => b;

    factory StockMovement([void updates(StockMovementBuilder b)]) = _$StockMovement;

    @BuiltValueSerializer(custom: true)
    static Serializer<StockMovement> get serializer => _$StockMovementSerializer();
}

class _$StockMovementSerializer implements StructuredSerializer<StockMovement> {

    @override
    final Iterable<Type> types = const [StockMovement, _$StockMovement];
    @override
    final String wireName = r'StockMovement';

    @override
    Iterable<Object> serialize(Serializers serializers, StockMovement object,
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
        if (object.operationId != null) {
            result
                ..add(r'operationId')
                ..add(serializers.serialize(object.operationId,
                    specifiedType: const FullType(String)));
        }
        result
            ..add(r'movementType')
            ..add(serializers.serialize(object.movementType,
                specifiedType: const FullType(StoreProductMovementType)));
        result
            ..add(r'direction')
            ..add(serializers.serialize(object.direction,
                specifiedType: const FullType(LedgerDirection)));
        result
            ..add(r'quantity')
            ..add(serializers.serialize(object.quantity,
                specifiedType: const FullType(int)));
        result
            ..add(r'state')
            ..add(serializers.serialize(object.state,
                specifiedType: const FullType(LedgerEntryState)));
        if (object.reversalOfId != null) {
            result
                ..add(r'reversalOfId')
                ..add(serializers.serialize(object.reversalOfId,
                    specifiedType: const FullType(String)));
        }
        if (object.description != null) {
            result
                ..add(r'description')
                ..add(serializers.serialize(object.description,
                    specifiedType: const FullType(String)));
        }
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
    StockMovement deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = StockMovementBuilder();

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
                        specifiedType: const FullType(StoreProductMovementType)) as StoreProductMovementType;
                    break;
                case r'direction':
                    result.direction = serializers.deserialize(value,
                        specifiedType: const FullType(LedgerDirection)) as LedgerDirection;
                    break;
                case r'quantity':
                    result.quantity = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'state':
                    result.state = serializers.deserialize(value,
                        specifiedType: const FullType(LedgerEntryState)) as LedgerEntryState;
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

