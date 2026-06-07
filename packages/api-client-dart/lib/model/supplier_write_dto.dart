//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:mansis_pos_api_client/model/model_null.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'supplier_write_dto.g.dart';

abstract class SupplierWriteDto implements Built<SupplierWriteDto, SupplierWriteDtoBuilder> {

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'userId')
    String get userId;

    @BuiltValueField(wireName: r'name')
    String get name;

    @nullable
    @BuiltValueField(wireName: r'authorizedPerson')
    String get authorizedPerson;

    @nullable
    @BuiltValueField(wireName: r'address')
    String get address;

    @nullable
    @BuiltValueField(wireName: r'phone')
    String get phone;

    @nullable
    @BuiltValueField(wireName: r'mail')
    String get mail;

    @nullable
    @BuiltValueField(wireName: r'taxOffice')
    String get taxOffice;

    @nullable
    @BuiltValueField(wireName: r'taxNo')
    String get taxNo;

    @nullable
    @BuiltValueField(wireName: r'taxFree')
    bool get taxFree;

    @nullable
    @BuiltValueField(wireName: r'moneyUnitType')
    OneOfnullinteger get moneyUnitType;

    @nullable
    @BuiltValueField(wireName: r'maturity')
    int get maturity;

    @nullable
    @BuiltValueField(wireName: r'openingBalance')
    double get openingBalance;

    SupplierWriteDto._();

    static void _initializeBuilder(SupplierWriteDtoBuilder b) => b;

    factory SupplierWriteDto([void updates(SupplierWriteDtoBuilder b)]) = _$SupplierWriteDto;

    @BuiltValueSerializer(custom: true)
    static Serializer<SupplierWriteDto> get serializer => _$SupplierWriteDtoSerializer();
}

class _$SupplierWriteDtoSerializer implements StructuredSerializer<SupplierWriteDto> {

    @override
    final Iterable<Type> types = const [SupplierWriteDto, _$SupplierWriteDto];
    @override
    final String wireName = r'SupplierWriteDto';

    @override
    Iterable<Object> serialize(Serializers serializers, SupplierWriteDto object,
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
            ..add(r'authorizedPerson')
            ..add(object.authorizedPerson == null ? null : serializers.serialize(object.authorizedPerson,
                specifiedType: const FullType(String)));
        result
            ..add(r'address')
            ..add(object.address == null ? null : serializers.serialize(object.address,
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
            ..add(r'taxOffice')
            ..add(object.taxOffice == null ? null : serializers.serialize(object.taxOffice,
                specifiedType: const FullType(String)));
        result
            ..add(r'taxNo')
            ..add(object.taxNo == null ? null : serializers.serialize(object.taxNo,
                specifiedType: const FullType(String)));
        result
            ..add(r'taxFree')
            ..add(object.taxFree == null ? null : serializers.serialize(object.taxFree,
                specifiedType: const FullType(bool)));
        result
            ..add(r'moneyUnitType')
            ..add(object.moneyUnitType == null ? null : serializers.serialize(object.moneyUnitType,
                specifiedType: const FullType(OneOfnullinteger)));
        result
            ..add(r'maturity')
            ..add(object.maturity == null ? null : serializers.serialize(object.maturity,
                specifiedType: const FullType(int)));
        result
            ..add(r'openingBalance')
            ..add(object.openingBalance == null ? null : serializers.serialize(object.openingBalance,
                specifiedType: const FullType(double)));
        return result;
    }

    @override
    SupplierWriteDto deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = SupplierWriteDtoBuilder();

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
                case r'authorizedPerson':
                    result.authorizedPerson = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'address':
                    result.address = serializers.deserialize(value,
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
                case r'taxOffice':
                    result.taxOffice = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'taxNo':
                    result.taxNo = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'taxFree':
                    result.taxFree = serializers.deserialize(value,
                        specifiedType: const FullType(bool)) as bool;
                    break;
                case r'moneyUnitType':
                    result.moneyUnitType.replace(serializers.deserialize(value,
                        specifiedType: const FullType(OneOfnullinteger)) as OneOfnullinteger);
                    break;
                case r'maturity':
                    result.maturity = serializers.deserialize(value,
                        specifiedType: const FullType(int)) as int;
                    break;
                case r'openingBalance':
                    result.openingBalance = serializers.deserialize(value,
                        specifiedType: const FullType(double)) as double;
                    break;
            }
        }
        return result.build();
    }
}

