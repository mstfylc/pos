//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'identified_customer_dto.g.dart';

abstract class IdentifiedCustomerDto implements Built<IdentifiedCustomerDto, IdentifiedCustomerDtoBuilder> {

    @BuiltValueField(wireName: r'customerId')
    String get customerId;

    @BuiltValueField(wireName: r'name')
    String get name;

    @BuiltValueField(wireName: r'surname')
    String get surname;

    @nullable
    @BuiltValueField(wireName: r'phone')
    String get phone;

    @nullable
    @BuiltValueField(wireName: r'mail')
    String get mail;

    @BuiltValueField(wireName: r'walletBalance')
    double get walletBalance;

    @BuiltValueField(wireName: r'pointBalance')
    int get pointBalance;

    @BuiltValueField(wireName: r'lifetimePoints')
    int get lifetimePoints;

    @nullable
    @BuiltValueField(wireName: r'tierId')
    String get tierId;

    @nullable
    @BuiltValueField(wireName: r'tierName')
    String get tierName;

    IdentifiedCustomerDto._();

    static void _initializeBuilder(IdentifiedCustomerDtoBuilder b) => b;

    factory IdentifiedCustomerDto([void updates(IdentifiedCustomerDtoBuilder b)]) = _$IdentifiedCustomerDto;

    @BuiltValueSerializer(custom: true)
    static Serializer<IdentifiedCustomerDto> get serializer => _$IdentifiedCustomerDtoSerializer();
}

class _$IdentifiedCustomerDtoSerializer implements StructuredSerializer<IdentifiedCustomerDto> {

    @override
    final Iterable<Type> types = const [IdentifiedCustomerDto, _$IdentifiedCustomerDto];
    @override
    final String wireName = r'IdentifiedCustomerDto';

    @override
    Iterable<Object> serialize(Serializers serializers, IdentifiedCustomerDto object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'customerId')
            ..add(serializers.serialize(object.customerId,
                specifiedType: const FullType(String)));
        result
            ..add(r'name')
            ..add(serializers.serialize(object.name,
                specifiedType: const FullType(String)));
        result
            ..add(r'surname')
            ..add(serializers.serialize(object.surname,
                specifiedType: const FullType(String)));
        result
            ..add(r'phone')
            ..add(object.phone == null ? null : serializers.serialize(object.phone,
                specifiedType: const FullType(String)));
        result
            ..add(r'mail')
            ..add(object.mail == null ? null : serializers.serialize(object.mail,
                specifiedType: const FullType(String)));
        result
            ..add(r'walletBalance')
            ..add(serializers.serialize(object.walletBalance,
                specifiedType: const FullType(double)));
        result
            ..add(r'pointBalance')
            ..add(serializers.serialize(object.pointBalance,
                specifiedType: const FullType(int)));
        result
            ..add(r'lifetimePoints')
            ..add(serializers.serialize(object.lifetimePoints,
                specifiedType: const FullType(int)));
        result
            ..add(r'tierId')
            ..add(object.tierId == null ? null : serializers.serialize(object.tierId,
                specifiedType: const FullType(String)));
        result
            ..add(r'tierName')
            ..add(object.tierName == null ? null : serializers.serialize(object.tierName,
                specifiedType: const FullType(String)));
        return result;
    }

    @override
    IdentifiedCustomerDto deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = IdentifiedCustomerDtoBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'customerId':
                    result.customerId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'name':
                    result.name = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'surname':
                    result.surname = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'phone':
                    result.phone = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'mail':
                    result.mail = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'walletBalance':
                    result.walletBalance = serializers.deserialize(value,
                        specifiedType: const FullType(double)) as double;
                    break;
                case r'pointBalance':
                    result.pointBalance = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'lifetimePoints':
                    result.lifetimePoints = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'tierId':
                    result.tierId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'tierName':
                    result.tierName = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
            }
        }
        return result.build();
    }
}

