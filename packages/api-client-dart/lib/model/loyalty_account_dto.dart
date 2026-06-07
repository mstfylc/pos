//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'loyalty_account_dto.g.dart';

abstract class LoyaltyAccountDto implements Built<LoyaltyAccountDto, LoyaltyAccountDtoBuilder> {

    @BuiltValueField(wireName: r'id')
    String get id;

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'customerId')
    String get customerId;

    @nullable
    @BuiltValueField(wireName: r'loyaltyTierId')
    String get loyaltyTierId;

    @BuiltValueField(wireName: r'pointBalance')
    int get pointBalance;

    @BuiltValueField(wireName: r'lifetimePoints')
    int get lifetimePoints;

    LoyaltyAccountDto._();

    static void _initializeBuilder(LoyaltyAccountDtoBuilder b) => b;

    factory LoyaltyAccountDto([void updates(LoyaltyAccountDtoBuilder b)]) = _$LoyaltyAccountDto;

    @BuiltValueSerializer(custom: true)
    static Serializer<LoyaltyAccountDto> get serializer => _$LoyaltyAccountDtoSerializer();
}

class _$LoyaltyAccountDtoSerializer implements StructuredSerializer<LoyaltyAccountDto> {

    @override
    final Iterable<Type> types = const [LoyaltyAccountDto, _$LoyaltyAccountDto];
    @override
    final String wireName = r'LoyaltyAccountDto';

    @override
    Iterable<Object> serialize(Serializers serializers, LoyaltyAccountDto object,
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
            ..add(r'customerId')
            ..add(serializers.serialize(object.customerId,
                specifiedType: const FullType(String)));
        result
            ..add(r'loyaltyTierId')
            ..add(object.loyaltyTierId == null ? null : serializers.serialize(object.loyaltyTierId,
                specifiedType: const FullType(String)));
        result
            ..add(r'pointBalance')
            ..add(serializers.serialize(object.pointBalance,
                specifiedType: const FullType(int)));
        result
            ..add(r'lifetimePoints')
            ..add(serializers.serialize(object.lifetimePoints,
                specifiedType: const FullType(int)));
        return result;
    }

    @override
    LoyaltyAccountDto deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = LoyaltyAccountDtoBuilder();

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
                case r'customerId':
                    result.customerId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'loyaltyTierId':
                    result.loyaltyTierId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'pointBalance':
                    result.pointBalance = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'lifetimePoints':
                    result.lifetimePoints = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
            }
        }
        return result.build();
    }
}

