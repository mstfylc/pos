//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'company.g.dart';

abstract class Company implements Built<Company, CompanyBuilder> {

    @BuiltValueField(wireName: r'id')
    String get id;

    @BuiltValueField(wireName: r'name')
    String get name;

    @BuiltValueField(wireName: r'active')
    bool get active;

    Company._();

    static void _initializeBuilder(CompanyBuilder b) => b;

    factory Company([void updates(CompanyBuilder b)]) = _$Company;

    @BuiltValueSerializer(custom: true)
    static Serializer<Company> get serializer => _$CompanySerializer();
}

class _$CompanySerializer implements StructuredSerializer<Company> {

    @override
    final Iterable<Type> types = const [Company, _$Company];
    @override
    final String wireName = r'Company';

    @override
    Iterable<Object> serialize(Serializers serializers, Company object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'id')
            ..add(serializers.serialize(object.id,
                specifiedType: const FullType(String)));
        result
            ..add(r'name')
            ..add(serializers.serialize(object.name,
                specifiedType: const FullType(String)));
        result
            ..add(r'active')
            ..add(serializers.serialize(object.active,
                specifiedType: const FullType(bool)));
        return result;
    }

    @override
    Company deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = CompanyBuilder();

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
                case r'name':
                    result.name = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'active':
                    result.active = serializers.deserialize(value,
                        specifiedType: const FullType(bool)) as bool;
                    break;
            }
        }
        return result.build();
    }
}

