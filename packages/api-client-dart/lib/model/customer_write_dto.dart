//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_collection/built_collection.dart';
import 'package:mansis_pos_api_client/model/address_write_dto.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'customer_write_dto.g.dart';

abstract class CustomerWriteDto implements Built<CustomerWriteDto, CustomerWriteDtoBuilder> {

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'userId')
    String get userId;

    @BuiltValueField(wireName: r'name')
    String get name;

    @BuiltValueField(wireName: r'surname')
    String get surname;

    @BuiltValueField(wireName: r'username')
    String get username;

    @nullable
    @BuiltValueField(wireName: r'phone')
    String get phone;

    @nullable
    @BuiltValueField(wireName: r'mail')
    String get mail;

    @BuiltValueField(wireName: r'roleId')
    String get roleId;

    @nullable
    @BuiltValueField(wireName: r'addresses')
    BuiltList<AddressWriteDto> get addresses;

    CustomerWriteDto._();

    static void _initializeBuilder(CustomerWriteDtoBuilder b) => b;

    factory CustomerWriteDto([void updates(CustomerWriteDtoBuilder b)]) = _$CustomerWriteDto;

    @BuiltValueSerializer(custom: true)
    static Serializer<CustomerWriteDto> get serializer => _$CustomerWriteDtoSerializer();
}

class _$CustomerWriteDtoSerializer implements StructuredSerializer<CustomerWriteDto> {

    @override
    final Iterable<Type> types = const [CustomerWriteDto, _$CustomerWriteDto];
    @override
    final String wireName = r'CustomerWriteDto';

    @override
    Iterable<Object> serialize(Serializers serializers, CustomerWriteDto object,
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
            ..add(r'name')
            ..add(serializers.serialize(object.name,
                specifiedType: const FullType(String)));
        result
            ..add(r'surname')
            ..add(serializers.serialize(object.surname,
                specifiedType: const FullType(String)));
        result
            ..add(r'username')
            ..add(serializers.serialize(object.username,
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
            ..add(r'roleId')
            ..add(serializers.serialize(object.roleId,
                specifiedType: const FullType(String)));
        if (object.addresses != null) {
            result
                ..add(r'addresses')
                ..add(serializers.serialize(object.addresses,
                    specifiedType: const FullType(BuiltList, [FullType(AddressWriteDto)])));
        }
        return result;
    }

    @override
    CustomerWriteDto deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = CustomerWriteDtoBuilder();

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
                case r'name':
                    result.name = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'surname':
                    result.surname = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'username':
                    result.username = serializers.deserialize(value,
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
                case r'roleId':
                    result.roleId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'addresses':
                    result.addresses.replace(serializers.deserialize(value,
                        specifiedType: const FullType(BuiltList, [FullType(AddressWriteDto)])) as BuiltList<AddressWriteDto>);
                    break;
            }
        }
        return result.build();
    }
}

