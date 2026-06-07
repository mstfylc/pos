//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'loyalty_account.g.dart';

abstract class LoyaltyAccount implements Built<LoyaltyAccount, LoyaltyAccountBuilder> {

    @BuiltValueField(wireName: r'id')
    String get id;

    @BuiltValueField(wireName: r'customerId')
    String get customerId;

    @nullable
    @BuiltValueField(wireName: r'tierName')
    String get tierName;

    @BuiltValueField(wireName: r'pointBalance')
    int get pointBalance;

    LoyaltyAccount._();

    static void _initializeBuilder(LoyaltyAccountBuilder b) => b;

    factory LoyaltyAccount([void updates(LoyaltyAccountBuilder b)]) = _$LoyaltyAccount;

    @BuiltValueSerializer(custom: true)
    static Serializer<LoyaltyAccount> get serializer => _$LoyaltyAccountSerializer();
}

class _$LoyaltyAccountSerializer implements StructuredSerializer<LoyaltyAccount> {

    @override
    final Iterable<Type> types = const [LoyaltyAccount, _$LoyaltyAccount];
    @override
    final String wireName = r'LoyaltyAccount';

    @override
    Iterable<Object> serialize(Serializers serializers, LoyaltyAccount object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'id')
            ..add(serializers.serialize(object.id,
                specifiedType: const FullType(String)));
        result
            ..add(r'customerId')
            ..add(serializers.serialize(object.customerId,
                specifiedType: const FullType(String)));
        if (object.tierName != null) {
            result
                ..add(r'tierName')
                ..add(serializers.serialize(object.tierName,
                    specifiedType: const FullType(String)));
        }
        result
            ..add(r'pointBalance')
            ..add(serializers.serialize(object.pointBalance,
                specifiedType: const FullType(int)));
        return result;
    }

    @override
    LoyaltyAccount deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = LoyaltyAccountBuilder();

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
                case r'customerId':
                    result.customerId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'tierName':
                    result.tierName = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'pointBalance':
                    result.pointBalance = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
            }
        }
        return result.build();
    }
}

